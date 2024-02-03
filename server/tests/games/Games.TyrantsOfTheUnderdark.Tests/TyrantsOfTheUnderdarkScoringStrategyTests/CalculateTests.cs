using System.Collections.Generic;
using System.Text.Json;
using Autofac.Extras.Moq;
using BGS.ApplicationCore.Games.CalculateScore;
using FluentAssertions;
using Xunit;

namespace BGS.Games.TyrantsOfTheUnderdark.Tests.TyrantsOfTheUnderdarkScoringStrategyTests;

public class CalculateTests
{
    private readonly TyrantsOfTheUnderdarkScoringStrategy _sut =
        AutoMock.GetLoose().Create<TyrantsOfTheUnderdarkScoringStrategy>();

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
        yield return [GetTyrantsOfTheUnderdarkGameDataJsonElement(0, 0, 0, 0, 0, 0), 0];
        yield return [GetTyrantsOfTheUnderdarkGameDataJsonElement(39, 0, 22, 16, 3, 0), 80];
        yield return [GetTyrantsOfTheUnderdarkGameDataJsonElement(22, 1, 19, 17, 5, 1), 66];
        yield return [GetTyrantsOfTheUnderdarkGameDataJsonElement(22, 2, 14, 5, 0, 0), 45];
        yield return [GetTyrantsOfTheUnderdarkGameDataJsonElement(26, 6, 23, 14, 13, 20), 108];
    }

    private static JsonElement GetTyrantsOfTheUnderdarkGameDataJsonElement(
        byte controlSitesScore,
        byte totalControlSitesScore,
        byte troopsTrophyHallScore,
        byte deckValueScore,
        byte innerCircleDeckValueScore,
        byte victoryPointTokensScore)
    {
        return JsonSerializer.SerializeToElement(
            new TyrantsOfTheUnderdarkScoringModel
            {
                ControlSitesScore = controlSitesScore,
                TotalControlSitesScore = totalControlSitesScore,
                TroopsTrophyHallScore = troopsTrophyHallScore,
                DeckValueScore = deckValueScore,
                InnerCircleDeckValueScore = innerCircleDeckValueScore,
                VictoryPointTokensScore = victoryPointTokensScore,
            });
    }
}