using System.Collections.Generic;
using System.Text.Json;
using Autofac.Extras.Moq;
using BGS.ApplicationCore.Games.CalculateScore;
using FluentAssertions;
using Xunit;

namespace BGS.Games.BattleForRokugan.Tests.BattleForRokuganScoringStrategyTests;

public class CalculateTests
{
    private readonly BattleForRokuganCalculator _sut =
        AutoMock.GetLoose().Create<BattleForRokuganCalculator>();

    [Theory]
    [MemberData(nameof(GameDataWithExpectedResultTestCases))]
    public void ShouldCalculateCorrectly(JsonElement gameData, int expectedResult)
    {
        // Arrange
        var models = new PlayerCalculationModel[] { new () { GameData = gameData } };

        // Act
        var result = _sut.Calculate(models);

        // Assert
        result.Should().HaveCount(models.Length).And.OnlyContain(model => model.TotalScore == expectedResult);
    }

    public static IEnumerable<object[]> GameDataWithExpectedResultTestCases()
    {
        yield return [GetBattleForRokuganGameDataJsonElement(0, 0, 0, 0), 0];
        yield return [GetBattleForRokuganGameDataJsonElement(0, 0, 6, 0), 6];
        yield return [GetBattleForRokuganGameDataJsonElement(10, 3, 6, 0), 19];
        yield return [GetBattleForRokuganGameDataJsonElement(8, 6, 0, 2), 24];
        yield return [GetBattleForRokuganGameDataJsonElement(13, 9, 5, 3), 42];
    }

    private static JsonElement GetBattleForRokuganGameDataJsonElement(
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