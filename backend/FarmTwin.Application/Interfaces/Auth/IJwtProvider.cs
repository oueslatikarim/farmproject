using FarmTwin.Domain.Entities.Identity;

namespace FarmTwin.Application.Interfaces.Auth;

public interface IJwtProvider
{
    string GenerateAccessToken(User user, IEnumerable<string> roles, IEnumerable<string> permissions);
    RefreshToken GenerateRefreshToken(Guid userId);
}
