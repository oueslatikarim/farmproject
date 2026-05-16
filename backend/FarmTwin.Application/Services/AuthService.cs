using FarmTwin.Application.Interfaces.Auth;
using FarmTwin.Application.Models.Auth;
using FarmTwin.Domain.Entities.Audit;
using FarmTwin.Domain.Entities.Identity;
using FarmTwin.Infrastructure.Data; // I should abstract this, but following simpler Clean Arch for now
using Microsoft.EntityFrameworkCore;

namespace FarmTwin.Application.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public AuthService(ApplicationDbContext dbContext, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ThenInclude(r => r.RolePermissions).ThenInclude(rp => rp.Permission)
            .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

        if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash) || !user.IsActive)
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        return await GenerateAuthResponseAsync(user, cancellationToken);
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        if (await _dbContext.Users.AnyAsync(u => u.Email == request.Email, cancellationToken))
        {
            throw new InvalidOperationException("Email already exists.");
        }

        var user = new User
        {
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return await GenerateAuthResponseAsync(user, cancellationToken);
    }

    public async Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken = default)
    {
        var refreshToken = await _dbContext.RefreshTokens
            .Include(r => r.User)
            .ThenInclude(u => u.UserRoles).ThenInclude(ur => ur.Role).ThenInclude(r => r.RolePermissions).ThenInclude(rp => rp.Permission)
            .FirstOrDefaultAsync(r => r.Token == request.RefreshToken, cancellationToken);

        if (refreshToken == null || !refreshToken.IsActive)
        {
            throw new UnauthorizedAccessException("Invalid refresh token.");
        }

        // Revoke the old token
        refreshToken.RevokedAt = DateTime.UtcNow;

        return await GenerateAuthResponseAsync(refreshToken.User, cancellationToken);
    }

    private async Task<AuthResponse> GenerateAuthResponseAsync(User user, CancellationToken cancellationToken)
    {
        var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
        var permissions = user.UserRoles
            .SelectMany(ur => ur.Role.RolePermissions)
            .Select(rp => rp.Permission.SystemName)
            .Distinct()
            .ToList();

        var accessToken = _jwtProvider.GenerateAccessToken(user, roles, permissions);
        var refreshToken = _jwtProvider.GenerateRefreshToken(user.Id);

        _dbContext.RefreshTokens.Add(refreshToken);
        
        _dbContext.AuditLogs.Add(new AuditLog
        {
            UserId = user.Id.ToString(),
            Action = "Login/TokenGeneration",
            EntityName = "User",
            EntityId = user.Id.ToString()
        });

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new AuthResponse
        {
            Token = accessToken,
            RefreshToken = refreshToken.Token
        };
    }
}
