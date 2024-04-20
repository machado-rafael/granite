using Calculo.CalculoDomain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Calculo.CalculoServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoController : ControllerBase
    {
        private readonly ICalculoService _calculoService;

        public CalculoController(ICalculoService calculoService) 
        {
            _calculoService = calculoService;
        }

        [HttpGet("calculajuros")]
        public IActionResult Get(decimal valorInicial, int meses)
        {

            return Ok(_calculoService.CalculaJuros(valorInicial, meses));
        }

        [HttpGet("showmethecode")]
        public IActionResult GetCode()
        {

            return Ok(_calculoService.RetornaRepositorio());
        }
    }
}
