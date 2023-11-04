using System.Collections.Generic;
using System.Text.Json;
using Autofac.Extras.Moq;
using FluentAssertions;
using Xunit;

namespace BGS.Games.BattleForRokugan.Tests.BattleForRokuganScoringStrategyTests;

public class CalculateTests
{
    private readonly BattleForRokuganScoringStrategy _sut;

    public CalculateTests()
    {
        _sut = AutoMock.GetLoose().Create<BattleForRokuganScoringStrategy>();
    }

    [Theory]
    [MemberData(nameof(ScoringDataWithExpectedResultTestCases))]
    public void ShouldCalculateCorrectly(JsonElement scoringData, int expectedResult)
    {
        // Arrange & Act
        var result = _sut.Calculate(scoringData);

        // Assert
        result.Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> ScoringDataWithExpectedResultTestCases()
    {
        yield return new object[] { GetBattleForRokuganScoringJsonElement(0, 0, 0, 0), 0 };
        yield return new object[] { GetBattleForRokuganScoringJsonElement(0, 0, 6, 0), 6 };
        yield return new object[] { GetBattleForRokuganScoringJsonElement(10, 3, 6, 0), 19 };
        yield return new object[] { GetBattleForRokuganScoringJsonElement(8, 6, 0, 2), 24 };
        yield return new object[] { GetBattleForRokuganScoringJsonElement(13, 9, 5, 3), 42 };
    }

    private static JsonElement GetBattleForRokuganScoringJsonElement(
        byte countOfProvincialFlowers,
        byte countOfFaceUpControlTokens,
        byte secretObjectivePoints,
        byte countOfControlledTerritories)
    {
        return JsonSerializer.SerializeToElement(
            new BattleForRokuganScoringModel
            {
                CountOfProvincialFlowers = countOfProvincialFlowers,
                CountOfFaceUpControlTokens = countOfFaceUpControlTokens,
                SecretObjectivePoints = secretObjectivePoints,
                CountOfControlledTerritories = countOfControlledTerritories,
            });
    }
}