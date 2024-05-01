
using DotProducts.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotProducts.Controllers;

[ApiController]
[Route("products")]
public class ProdutosController : ControllerBase {
    private readonly AppDbContext db;
    public ProdutosController(AppDbContext dbContext){
        db = dbContext;
    }
    [HttpGet]
    public ActionResult GetAll(){
        var produtos = db.Produtos.ToList();
        return Ok(produtos);
    }
    [HttpGet(":id")]
    public ActionResult GetById(int id){
        var produto = db.Produtos.Find(id);
        return Ok(produto);
    }
    [HttpPost]
    public ActionResult PostProduto(Produto produto){
        db.Produtos.Add(produto);
        db.SaveChanges();
        return Created("", new {message = "Produto registrado com sucesso!"});
    }
    [HttpDelete]
    public ActionResult Delete(int id){
        var produto = db.Produtos.Find(id);
        if(produto == null) return NotFound();
        db.Produtos.Remove(produto);
        db.SaveChanges();
        return Ok();
    }

}