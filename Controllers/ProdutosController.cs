using Microsoft.AspNetCore.Mvc;

namespace DotProducts.Controllers;

[ApiController]
[Route("products")]
public class ProdutosController : ControllerBase {
    [HttpGet]
    public string Get(){
        return "Teste 123";
    }
}