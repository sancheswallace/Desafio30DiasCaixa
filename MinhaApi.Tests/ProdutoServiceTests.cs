using Moq;
using Xunit;
using MinhaApi.Services;
using MinhaApi.Data;
using MinhaApi.Models;

public class ProdutoServiceTests
{
    [Fact]
    public void ObterPorId_DeveRetornarProduto()
    {
        // Arrange
        var mockRepo = new Mock<IProdutoRepository>();
        mockRepo.Setup(r => r.BuscarPorId(1))
                .Returns(new Produto(1, "Mouse", 50));

        var service = new ProdutoService(mockRepo.Object);

        // Act
        var resultado = service.ObterPorId(1);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal("Mouse", resultado.Nome);
    }

    [Fact]
    public void Criar_DeveChamarAdicionarNoRepositorio()
    {
        // Arrange
        var mockRepo = new Mock<IProdutoRepository>();
        var service = new ProdutoService(mockRepo.Object);
        var produto = new Produto(1, "Teclado", 100);

        // Act
        service.Criar(produto);

        // Assert
        mockRepo.Verify(r => r.Adicionar(produto), Times.Once);
    }
}
