using Moq;
using Xunit;
using Fiap.Hackatoon.Product.Consumer.Application.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Services;
using Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures.Entities;
using EN = Fiap.Hackatoon.Product.Consumer.Domain.Entities;

using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;

public class ContactServiceUnitTests
{
    private readonly Mock<IContactRepository> _contactRepositoryMock;
    private readonly Mock<IStateDDDRepository> _stateDDDRepositoryMock;

    private readonly Mock<IStateDDDService> _stateDDDServiceMock;
    private readonly Mock<EN.UserData> _userDataMock;
    private readonly IContactService _contactService;

    public ContactServiceUnitTests()
    {
        _contactRepositoryMock = new Mock<IContactRepository>();
        _stateDDDRepositoryMock = new Mock<IStateDDDRepository>();
        _stateDDDServiceMock = new Mock<IStateDDDService>();
        _userDataMock = new Mock<EN.UserData>();

        _contactService = new ContactService(
            _contactRepositoryMock.Object,
            _userDataMock.Object,
            _stateDDDServiceMock.Object
        );
    }

    [Fact]
    public async Task Delete_ValidId_ShouldCallRepositoryOnce()
    {
        // Arrange
        var contactId = Guid.NewGuid();
        _contactRepositoryMock.Setup(repo => repo.Delete(contactId))
                              .Returns(Task.CompletedTask);

        // Act
        await _contactService.Delete(contactId);

        // Assert
        _contactRepositoryMock.Verify(repo => repo.Delete(contactId), Times.Once);
    }
}
