using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Services;
using Fiap.Hackatoon.Product.Consumer.Infrastructure.Data;
using Fiap.Hackatoon.Product.Consumer.Infrastructure.Data.Repositories;
using MSG = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects.MessageBrokers;
using DTO = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects;
using AutoMapper;
using Fiap.Hackatoon.Product.Consumer.Application.Services;
using Fiap.Hackatoon.Product.Consumer.Application.Mappings;
using Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures.DataTransferObjects;
using Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures;
using Moq;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.ElasticSearch;

namespace Fiap.Hackatoon.Product.Consumer.Tests.Integration
{
    public class ProductApplicationIntegrationTests : IAsyncLifetime
    {
        private readonly ApplicationDBContext _context;
        private readonly ProductApplicationService _application;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductApplicationIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDBContext(options);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductMapper>();
            });
            _mapper = config.CreateMapper();
            var mockElasticService = new Mock<IProductElasticSearchService>();
            _productService = new ProductService(new ProductRepository(_context));
            _application = new ProductApplicationService(_productService, _mapper, mockElasticService.Object);
        }

        public async Task DisposeAsync()
        {
            await _context.Database.EnsureDeletedAsync();
            _context.Dispose();
        }

        [Fact]
        public async Task ShouldInsertProduct()
        {
            // Arrange
            var product = ProductFixtures.CreateAs_Base();
            var type = ProductTypeFixtures.CreateAs_Base();

            await _context.AddAsync(type);
            await _context.SaveChangesAsync();

            product.TypeId = type.Id;

            // Act
            var result = await _application.Insert(product);

            // Assert
            var returnedProduct = Assert.IsType<DTO.Product>(result);
            Assert.NotNull(returnedProduct);
            Assert.Equal(product.Name, returnedProduct.Name);
            Assert.Equal(product.Description, returnedProduct.Description);
            Assert.Equal(product.Price, returnedProduct.Price);
            Assert.Equal(product.StockQuantity, returnedProduct.StockQuantity);
            Assert.Equal(product.TypeId, returnedProduct.TypeId);
            Assert.Equal(product.Status, returnedProduct.Status);
        }

        [Fact]
        public async Task ShouldUpdateContact()
        {
            // Arrange
            await ShouldInsertProduct();
            var products = _productService.GetAll();
            var product = _mapper.Map<MSG.Product>(products.FirstOrDefault());

            Assert.NotNull(product);
            product.Name = "Updated Name";

            // Act
            var result = await _application.Update(product);

            // Assert
            var updatedContact = Assert.IsType<DTO.Product>(result);
            Assert.NotNull(updatedContact);
            Assert.Equal("Updated Name", updatedContact.Name);
        }


        [Fact]
        public async Task ShouldRemoveContact()
        {
            // Arrange
            await ShouldInsertProduct();
            var product = _productService.GetAll().FirstOrDefault();

            // Act
            await _application.Remove(product?.Id ?? Guid.Empty);
        }

        public async Task InitializeAsync()
           => await _context.Database.EnsureDeletedAsync();
    }
}