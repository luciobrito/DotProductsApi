using static BCrypt.Net.BCrypt;
using DotProducts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Runtime.CompilerServices;
using DotProducts.Services;

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
    public String MyData(){
        //var userId = User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value;
        string id = User.UserId();
        Usuario usuario = db.Usuarios.Find(Int32.Parse(id));
        return usuario.Email;
    }
}