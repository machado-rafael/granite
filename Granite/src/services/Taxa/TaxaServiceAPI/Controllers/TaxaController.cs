using Microsoft.AspNetCore.Mvc;

namespace Taxa.TaxaServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaController : ControllerBase
    {
        [HttpGet(Name = "GetTaxa")]
        public IActionResult Get()
        {
            return Ok(1);
        }
    }
}
