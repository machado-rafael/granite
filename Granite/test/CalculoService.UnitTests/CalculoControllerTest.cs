using Calculo.CalculoDomain.Interfaces;
using Calculo.CalculoServiceAPI.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CalculoService.UnitTests
{
    public class CalculoControllerTest
    {
        private readonly CalculoController _controller;

        public CalculoControllerTest()
        {
            var mockalculoService = new Mock<ICalculoService>();
            _controller = new CalculoController(mockalculoService.Object);
        }

        [Fact]
        public void GetValorCalculado1()
        {
            var okObjectResult = _controller.Get(1500, 12);
            var okResult = Assert.IsType<OkObjectResult>(okObjectResult);
            Assert.Equal((decimal)1690.24, okResult.Value);
        }

        [Fact]
        public void GetValorCalculado2()
        {
            var okObjectResult = _controller.Get(1000, 36);
            var okResult = Assert.IsType<OkObjectResult>(okObjectResult);
            Assert.Equal(1430.77, okResult.Value);
        }

        [Fact]
        public void GetValorCalculadoZerado()
        {
            var okObjectResult = _controller.Get(0, 12);
            var okResult = Assert.IsType<OkObjectResult>(okObjectResult);
            Assert.Equal(0, okResult.Value);
        }

        [Fact]
        public void GetValorCalculadoMesZerado()
        {
            var okObjectResult = _controller.Get(1000, 0);
            var okResult = Assert.IsType<OkObjectResult>(okObjectResult);
            Assert.Equal(1000, okResult.Value);
        }

        [Fact]
        public void GetValorCalculadoTudoZerado()
        {
            var okObjectResult = _controller.Get(0, 0);
            var okResult = Assert.IsType<OkObjectResult>(okObjectResult);
            Assert.Equal(0, okResult.Value);
        }

        [Fact]
        public void GetValorCalculadoNegativo()
        {
            var okObjectResult = _controller.Get(-1000, 0);
            var okResult = Assert.IsType<OkObjectResult>(okObjectResult);
            Assert.Equal(0, okResult.Value);
        }
    }
}