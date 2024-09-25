using Application.Common.Models.Auth;
using Application.Interfaces.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth;

public class JwtService : IJwtService
{
    readonly JwtOptions _options;

    public JwtService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string Generate(LoginClaims claims)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.Key)), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            GetClaims(claims),
            null,
            DateTime.UtcNow.AddDays(10),
            signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    static List<Claim> GetClaims(LoginClaims loginClaims)
    {
        return
        [
            new("PhoneNumber", loginClaims.PhoneNumber),
        ];
    }
}