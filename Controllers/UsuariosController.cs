using static BCrypt.Net.BCrypt;
using DotProducts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
    [HttpGet("/mydata")]
    [Authorize]
    public ActionResult MyData(){
        var userId = User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value;
        var userData = db.Usuarios.Find(Int32.Parse(userId));
        return Ok(userData);
    }
}