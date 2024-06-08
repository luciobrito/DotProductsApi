
using DotProducts.Dtos;
using DotProducts.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotProducts.Controllers;

[ApiController]
[Route("products")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext db;
    public static IWebHostEnvironment environment;
    public ProdutosController(AppDbContext dbContext, IWebHostEnvironment _environment)
    {
        db = dbContext;
        environment = _environment;
    }
    [HttpGet]
    public ActionResult GetAll()
    {
        var produtos = db.Produtos.ToList();
        return Ok(produtos);
    }
    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        var produto = db.Produtos.Find(id);
        return Ok(produto);
    }
    [HttpPost]
    public ActionResult PostProduto([FromForm]Produto produto, [FromForm] IFormFile imagem)
    {
        string imageName = UploadProductImage(imagem);
        produto.Image = imageName;
        db.Produtos.Add(produto);
        db.SaveChanges();
        return Created("", new { message = "Produto registrado com sucesso!" });
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var produto = db.Produtos.Find(id);
        if (produto == null) return NotFound("Produto não encontrado");
        db.Produtos.Remove(produto);
        db.SaveChanges();
        return Ok();
    }
    [HttpPatch("update/{id}")]
    public Produto UpdateProduto([FromBody]UpdateProdutoDto produtoBody, int id){
        Produto produto = db.Produtos.Find(id);
        if(produtoBody.Descricao != string.Empty) produto.Descricao = produtoBody.Descricao;
        if(produtoBody.Nome != string.Empty) produto.Nome = produtoBody.Nome;
        if(produtoBody.Preco != 0 )produto.Preco = produtoBody.Preco;
         db.SaveChanges();
        return produto;
    }

 [ApiExplorerSettings(IgnoreApi = true)]
    public string UploadProductImage(IFormFile arquivo)
    {
        //Diretório onde ficarão armazenadas as imagens
        string image_dir = environment.ContentRootPath + @"\imagens\produtos\";
        try
        {
            //Cria o diretório se não existir
            if (!Directory.Exists(image_dir)) Directory.CreateDirectory(image_dir);
            //Nome do arquivo é uma Guid + extensão original do arquivo
            string newFileName =  Guid.NewGuid().ToString() + System.IO.Path.GetExtension(arquivo.FileName);
            using (FileStream fileStream = System.IO.File.Create(image_dir + newFileName))
            {
                arquivo.CopyToAsync(fileStream);
                fileStream.Flush();
                return newFileName;
            }
        }
        catch (Exception exception)
        {
            return exception.ToString();
        }
    }
    [HttpGet("imagem/{nomeArquivo}")]
    public PhysicalFileResult ImagemProduto(string nomeArquivo)
    {
        var filepath = Path.Combine(environment.ContentRootPath, @"imagens\produtos", nomeArquivo);
        return PhysicalFile(filepath, "image/jpg");
    }
    
}