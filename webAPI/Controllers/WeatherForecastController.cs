using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers;

// http://localhost:5235
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get(){
        string[] nombres = {"galo","pepe","elmago"};
        return nombres;
    }
}
