using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Controllers;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Services;

public class ClientesControllerTests
{
    [Fact]
    public void GetById_DeveRetornarOk_QuandoClienteExiste()
    {
        // Arrange
        var mockService = new Mock<IClienteService>();
        mockService.Setup(r => r.ObterPorId(1))
                .Returns(new Cliente(1, "João"));

        var controller = new ClientesController(mockService.Object);

        // Act
        var resultado = controller.GetById(1);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(resultado);
        var cliente = Assert.IsType<Cliente>(ok.Value);
        Assert.Equal("João", cliente.Nome);
    }

    [Fact]
    public void GetById_DeveRetornarNotFound_QuandoClienteNaoExiste()
    {
        // Arrange
        var mockService = new Mock<IClienteService>();
        _ = mockService.Setup(r => r.ObterPorId(99))
                .Returns((Cliente?)null);

        var controller = new ClientesController(mockService.Object);

        // Act
        var resultado = controller.GetById(99);

        // Assert
        Assert.IsType<NotFoundResult>(resultado);
    }
}
