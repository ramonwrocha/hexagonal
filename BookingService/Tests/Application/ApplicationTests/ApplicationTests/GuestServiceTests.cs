using Application.Guest;
using Application.Guest.Models.DTOs;
using Application.Guest.Models.Requests;
using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Domain.ValueObjects;
using FluentAssertions;
using Moq;

namespace ApplicationTests;

[TestClass]
public class GuestServiceTest
{
    private static GuestService _sut;
    private static MockRepository _mockRepository;
    private static Mock<IGuestRepository> _mockGuestRepository;

    [ClassInitialize]
    public static void InitClass(TestContext testContext)
    {
        _mockRepository = new MockRepository(MockBehavior.Default);
    }

    [TestInitialize]
    public void InitTest()
    {
        _mockGuestRepository = _mockRepository.Create<IGuestRepository>();

        _sut = new GuestService(_mockGuestRepository.Object);
    }

    [TestMethod]
    public async Task CreateGuestAsync_ShouldReturnGuestWithId_WhenGuestIsCreated()
    {
        _mockGuestRepository.Setup(x => x.Create(It.IsAny<GuestEntity>())).ReturnsAsync(1);
        _mockGuestRepository.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(new GuestEntity
        {
            Id = 1,
            Name = "Test",
            Surname = "Test",
            Email = new Email("test@gmail.com"),
            Type = 0,
            Document = new DocumentNumber
            {
                Number = "12345678",
                Type = DocumentType.IDCard
            }
        });

        var result = await _sut.CreateGuestAsync(BuildCreateGuestRequest());

        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Id.Should().Be(1);
    }

    private CreateGuestRequest BuildCreateGuestRequest()
    {
        return new CreateGuestRequest
        {
            Data = new GuestDto()
            {
                Name = "Test",
                Surname = "Test",
                Email = "",
                Type = "Adult",
                DocumentNumber = "12345678",
                DocumentType = "IDCard"
            }
        };
    }
}
