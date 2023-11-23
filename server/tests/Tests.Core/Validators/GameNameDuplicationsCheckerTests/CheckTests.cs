using Autofac.Extras.Moq;
using AutoFixture.Xunit2;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Specifications;
using BGS.ApplicationCore.Games.Validators;
using BGS.SharedKernel;
using FluentAssertions;
using Moq;
using Xunit;

namespace BGS.Tests.Core.Validators.GameNameDuplicationsCheckerTests;

public class CheckTests
{
    private readonly GameDuplicationChecker _sut;
    private readonly Mock<IRepository<Game>> _gameRepositoryMock;

    public CheckTests()
    {
        var autoMock = AutoMock.GetLoose();
        _sut = autoMock.Create<GameDuplicationChecker>();
        _gameRepositoryMock = autoMock.Mock<IRepository<Game>>();
    }
    
    [Theory, AutoData]
    public async Task ShouldReturnTrueIfNamesAreDuplicates(string gameName)
    {
        // Arrange
        CancellationToken cancellationToken = default;

        _gameRepositoryMock
            .Setup(s => s.AnyAsync(It.IsAny<GameByNameSpecification>(), cancellationToken))
            .ReturnsAsync(true);

        // Act
        var result = await _sut.Check(gameName);

        // Assert
        result.Should().BeTrue();
    }

    [Theory, AutoData]
    public async Task ShouldReturnFalseIfNamesAreNotDuplicates(string gameName)
    {
        // Arrange
        CancellationToken cancellationToken = default;

        _gameRepositoryMock
            .Setup(s => s.AnyAsync(It.IsAny<GameByNameSpecification>(), cancellationToken))
            .ReturnsAsync(false);

        // Act
        var result = await _sut.Check(gameName);

        // Assert
        result.Should().BeFalse();
    }
}