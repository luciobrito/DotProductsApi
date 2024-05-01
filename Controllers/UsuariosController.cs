using static BCrypt.Net.BCrypt;
using DotProducts.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotProducts.Controllers;

[ApiController]
[Route("users")]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext db;
    public UsuariosController(AppDbContext appDbContext){
        db = appDbContext;
    }
    [HttpPost]
    public ActionResult Register(Usuario usuario){
        usuario.Senha = HashPassword(usuario.Senha);
        db.Usuarios.Add(usuario);
        db.SaveChanges();
        return Created();
    }
}