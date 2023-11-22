using Autofac.Extras.Moq;
using AutoFixture.Xunit2;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Specifications;
using BGS.ApplicationCore.Validators;
using BGS.SharedKernel;
using FluentAssertions;
using Moq;
using Xunit;

namespace BGS.Tests.Core.Validators.GameNameDuplicationsCheckerTests;

public class CheckTests
{
    private readonly GameNameDuplicationsChecker _sut;
    private readonly Mock<IRepository<Game>> _gameRepositoryMock;

    public CheckTests()
    {
        var autoMock = AutoMock.GetLoose();
        _sut = autoMock.Create<GameNameDuplicationsChecker>();
        _gameRepositoryMock = autoMock.Mock<IRepository<Game>>();
    }
    
    [Theory, AutoData]
    public async Task ShouldReturnTrueIfNamesAreDuplicates(string gameName, CancellationToken cancellationToken)
    {
        // Arrange
        _gameRepositoryMock
            .Setup(s => s.AnyAsync(It.IsAny<GameNameDuplicationsSpecification>(), cancellationToken))
            .ReturnsAsync(true);

        // Act
        var result = await _sut.Check(gameName, cancellationToken);

        // Assert
        result.Should().BeTrue();
    }

    [Theory, AutoData]
    public async Task ShouldReturnFalseIfNamesAreNotDuplicates(string gameName, CancellationToken cancellationToken)
    {
        // Arrange
        _gameRepositoryMock
            .Setup(s => s.AnyAsync(It.IsAny<GameNameDuplicationsSpecification>(), cancellationToken))
            .ReturnsAsync(false);

        // Act
        var result = await _sut.Check(gameName, cancellationToken);

        // Assert
        result.Should().BeFalse();
    }
}