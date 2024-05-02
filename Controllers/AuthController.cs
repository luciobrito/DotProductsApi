using static BCrypt.Net.BCrypt;
using DotProducts.Models;
using DotProducts.Services;
using Microsoft.AspNetCore.Mvc;
using DotProducts.Dtos;

namespace DotProducts.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext db;
    public AuthController(AppDbContext appDbContext)
    {
        db = appDbContext;
    }
    [HttpPost("login")]
    public ActionResult Login(UserLoginDto userBody)
    {
        var usuario = db.Usuarios.Where(u => u.Email == userBody.Email).FirstOrDefault();
        string token = string.Empty;
        if (usuario == null) return NotFound(new { message = "Usuário não encontrado!" });
        if (userBody.Email == usuario.Email &&
           Verify(userBody.Senha, usuario.Senha))
        {
            token = TokenService.GenerateToken(usuario);
        }
        usuario.Senha = string.Empty;

        return Ok(new { Token = token });
    }
}