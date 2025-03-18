using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class HelloController : ControllerBase
{
  [HttpGet("world")]
  public IActionResult GetMessage()
  {
    return Ok("Hello .NET");
  }
}