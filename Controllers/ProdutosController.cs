
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
    [HttpPost]
    public ActionResult PostProduto(Produto produto){
        db.Produtos.Add(produto);
        db.SaveChanges();
        return Created("", new {message = "Produto registrado com sucesso!"});
    }
}