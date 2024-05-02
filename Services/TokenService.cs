using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotProducts.Models;
using Microsoft.IdentityModel.Tokens;

namespace DotProducts.Services;

public static class TokenService
{
    public static string GenerateToken(Usuario usuario)
    {
        var root = Directory.GetCurrentDirectory();
        var dotenv = Path.Combine(root, ".env");
        EnvConfig.Load(dotenv);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                new Claim("role", usuario.Role.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}