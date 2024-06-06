using static BCrypt.Net.BCrypt;
using DotProducts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DotProducts.Services;
using DotProducts.Dtos;
using System.Text.Json.Nodes;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

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
        int id = User.UserId();
        Usuario usuario = db.Usuarios.Find(id);
        return usuario.Email;
    }
    [HttpPatch("name")]
    [Authorize]
    /*Por algum motivo, as strings não são aceitas como Json no body
    então tive que usar um objeto json e pegar o valor pelo index. ObjetoJson["valor"]
    */ 
    public ActionResult UpdateName(JsonObject nome ){
       string novoNome = nome["nome"].ToString();
       if(novoNome is null || novoNome == string.Empty) return StatusCode(400, "Valor 'nome' é obrigatório"); 
        else {
            int AuthId = User.UserId();
            Usuario usuario = db.Usuarios.Find(AuthId);
            usuario.Nome = novoNome;
            db.SaveChanges();
            return Created("", new {message = "Nome atualizado com sucesso!"});
        }
    }
    [HttpPatch("password")]
    [Authorize]
    public ActionResult UpdateSenha(UpdatePasswordDto passwordDto){
        int AuthId = User.UserId();
        //string currentPassword = db.Usuarios.Where(x => x.Id == id).Select(x => x.Senha).FirstOrDefault();     
        Usuario usuario = db.Usuarios.Find(AuthId);
        //Comparar a senha que o usuário enviou com a Hash salva no banco.
        bool verifyPassword = Verify(passwordDto.oldPassword, usuario.Senha);
        if(verifyPassword)
        {
            usuario.Senha = HashPassword(passwordDto.newPassword);
            db.SaveChanges();
            return Created("", new {message = "Sua senha foi atualizada com sucesso!"});
        }
        return StatusCode(400, "Senha antiga está errada!");
    }
}