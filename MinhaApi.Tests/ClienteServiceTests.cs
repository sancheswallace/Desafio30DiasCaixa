using Moq;
using Xunit;
using MinhaApi.Services;
using MinhaApi.Data;
using MinhaApi.Models;

public class ClienteServiceTests
{
    [Fact]
    public void ObterPorId_DeveRetornarCliente()
    {
        // Arrange
        var mockRepo = new Mock<IClienteRepository>();
        mockRepo.Setup(r => r.BuscarPorId(1))
                .Returns(new Cliente(1, "João"));

        var service = new ClienteService(mockRepo.Object);

        // Act
        var resultado = service.ObterPorId(1);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal("João", resultado.Nome);
    }

    [Fact]
    public void Criar_DeveChamarAdicionarNoRepositorio()
    {
        // Arrange
        var mockRepo = new Mock<IClienteRepository>();
        var service = new ClienteService(mockRepo.Object);
        var cliente = new Cliente(1, "João");

        // Act
        service.Criar(cliente);

        // Assert
        mockRepo.Verify(r => r.Adicionar(cliente), Times.Once);
    }
}