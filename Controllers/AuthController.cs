using Microsoft.AspNetCore.Mvc;

namespace DotProducts.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public ActionResult Login(){
        //TODO
        return Ok();
    }
}