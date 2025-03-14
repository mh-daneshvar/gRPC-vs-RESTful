using Microsoft.AspNetCore.Mvc;
using RestApi.Models;

namespace RestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpPost("small")]
    public IActionResult GetSmall([FromBody] SmallRequest request)
    {
        return Ok(new { message = $"Hello, {request.Name}!" });
    }

    [HttpPost("medium")]
    public IActionResult GetMedium([FromBody] MediumRequest request)
    {
        return Ok(new
        {
            message = $"Hello, {request.Name}!",
            email = request.Email,
            phone = request.Phone
        });
    }

    [HttpPost("large")]
    public IActionResult GetLarge([FromBody] LargeRequest request)
    {
        return Ok(request);
    }
} 