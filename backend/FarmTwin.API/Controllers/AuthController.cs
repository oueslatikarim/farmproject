using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using FarmTwin.API.Models.Auth;
using FarmTwin.API.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FarmTwin.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtOptions _jwt;

    public AuthController(IOptions<JwtOptions> jwt)
    {
        _jwt = jwt.Value;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // NOTE: This is still demo-only auth. Replace with Identity/IdP before production.
        if (request.Username == "admin" && request.Password == "password")
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, request.Username),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
              issuer: _jwt.Issuer,
              audience: _jwt.Audience,
              claims: claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        return Unauthorized();
    }
}
