using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Controllers;
using MinhaApi.Services;
using MinhaApi.Models;

public class ProdutosControllerTests
{
    [Fact]
    public void GetById_DeveRetornarOk_QuandoProdutoExiste()
    {
        // Arrange
        var mockService = new Mock<IProdutoService>();
        mockService.Setup(s => s.ObterPorId(1))
                   .Returns(new Produto(1, "Mouse", 50));

        var controller = new ProdutosController(mockService.Object);

        // Act
        var resultado = controller.GetById(1);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(resultado);
        var produto = Assert.IsType<Produto>(ok.Value);
        Assert.Equal("Mouse", produto.Nome);
    }

    [Fact]
    public void GetById_DeveRetornarNotFound_QuandoProdutoNaoExiste()
    {
        // Arrange
        var mockService = new Mock<IProdutoService>();
        mockService.Setup(s => s.ObterPorId(99))
                   .Returns((Produto)null);

        var controller = new ProdutosController(mockService.Object);

        // Act
        var resultado = controller.GetById(99);

        // Assert
        Assert.IsType<NotFoundResult>(resultado);
    }
}
