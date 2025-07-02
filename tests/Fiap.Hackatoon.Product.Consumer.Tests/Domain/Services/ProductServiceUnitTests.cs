using Moq;
using Xunit;
using Fiap.Hackatoon.Product.Consumer.Application.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Services;
using Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures.Entities;
using EN = Fiap.Hackatoon.Product.Consumer.Domain.Entities;

using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;

public class ProductServiceUnitTests
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IProductTypeRepository> _productTypeRepositoryMock;
    private readonly IProductService _productService;

    public ProductServiceUnitTests()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _productTypeRepositoryMock = new Mock<IProductTypeRepository>();

        _productService = new ProductService(
            _productRepositoryMock.Object
        );
    }

    [Fact]
    public async Task Insert_ValidProduct_ShouldCallRepositoryOnce()
    {
        // Arrange
        var product = ProductFixtures.CreateAs_Base();

        _productRepositoryMock.Setup(repo => repo.Add(product))
                              .ReturnsAsync(product);

        // Act
        await _productService.Add(product);

        // Assert
        _productRepositoryMock.Verify(repo => repo.Add(product), Times.Once);
    }

    [Fact]
    public async Task Update_ValidProduct_ShouldCallRepositoryOnce()
    {
        // Arrange
        var product = ProductFixtures.CreateAs_Base();

        _productRepositoryMock.Setup(repo => repo.Update(product))
                              .ReturnsAsync(product);

        // Act
        await _productService.Update(product);

        // Assert
        _productRepositoryMock.Verify(repo => repo.Update(product), Times.Once);
    }

    [Fact]
    public async Task Delete_ValidId_ShouldCallRepositoryOnce()
    {
        // Arrange
        var productId = Guid.NewGuid();
        _productRepositoryMock.Setup(repo => repo.Delete(productId))
                              .Returns(Task.CompletedTask);

        // Act
        await _productService.Delete(productId);

        // Assert
        _productRepositoryMock.Verify(repo => repo.Delete(productId), Times.Once);
    }
}
