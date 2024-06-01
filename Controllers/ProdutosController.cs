
using DotProducts.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotProducts.Controllers;

[ApiController]
[Route("products")]
public class ProdutosController : ControllerBase {
    private readonly AppDbContext db;
    public static IWebHostEnvironment environment;
    public ProdutosController(AppDbContext dbContext, IWebHostEnvironment _environment){
        db = dbContext;
        environment = _environment;
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
    [HttpPost("imagem")]
    public async Task<string> UploadImage([FromForm] IFormFile arquivo){
        
            try{
                if(!Directory.Exists(environment.ContentRootPath + @"\imagens\")) 
                    Directory.CreateDirectory(environment.ContentRootPath + @"\imagens\");
                using(FileStream fileStream = 
                System.IO.File.Create(
                    environment.ContentRootPath + 
                    @"\imagens\" + 
                    Guid.NewGuid().ToString() +
                    System.IO.Path.GetExtension(arquivo.FileName)
                    ))
                {
                    await arquivo.CopyToAsync(fileStream);
                    fileStream.Flush();
                    return System.IO.Path.GetExtension(arquivo.FileName);
                }
            }
            catch(Exception exception){
                return exception.ToString();
            }
        
       

    }
    [HttpGet("imagem/{nomeArquivo}")]
    public PhysicalFileResult ImagemProduto(string nomeArquivo)
    {
        var filepath = Path.Combine(environment.ContentRootPath, "imagens", nomeArquivo);
        return PhysicalFile(filepath, "image/jpg");
    }
}