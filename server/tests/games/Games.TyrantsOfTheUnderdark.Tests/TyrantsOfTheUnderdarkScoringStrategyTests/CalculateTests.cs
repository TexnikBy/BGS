using System.Collections.Generic;
using System.Text.Json;
using Autofac.Extras.Moq;
using FluentAssertions;
using Xunit;

namespace BGS.Games.TyrantsOfTheUnderdark.Tests.TyrantsOfTheUnderdarkScoringStrategyTests;

public class CalculateTests
{
    private readonly TyrantsOfTheUnderdarkScoringStrategy _sut =
        AutoMock.GetLoose().Create<TyrantsOfTheUnderdarkScoringStrategy>();

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
        yield return new object[] { GetTyrantsOfTheUnderdarkScoringJsonElement(0, 0, 0, 0, 0, 0), 0 };
        yield return new object[] { GetTyrantsOfTheUnderdarkScoringJsonElement(39, 0, 22, 16, 3, 0), 80 };
        yield return new object[] { GetTyrantsOfTheUnderdarkScoringJsonElement(22, 1, 19, 17, 5, 1), 66 };
        yield return new object[] { GetTyrantsOfTheUnderdarkScoringJsonElement(22, 2, 14, 5, 0, 0), 45 };
        yield return new object[] { GetTyrantsOfTheUnderdarkScoringJsonElement(26, 6, 23, 14, 13, 20), 108 };
    }

    private static JsonElement GetTyrantsOfTheUnderdarkScoringJsonElement(
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