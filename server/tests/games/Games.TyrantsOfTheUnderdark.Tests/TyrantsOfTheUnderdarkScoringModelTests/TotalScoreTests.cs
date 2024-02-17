using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace BGS.Games.TyrantsOfTheUnderdark.Tests.TyrantsOfTheUnderdarkScoringModelTests;

public class TotalScoreTests
{
    [Theory]
    [MemberData(nameof(ScoringModelWithExpectedResultTestCases))]
    public void TotalScoreShouldBeEqualExpectedResult(TyrantsOfTheUnderdarkScoringModel model, int expectedResult)
    {
        // Arrange & Act & Assert
        model.TotalScore.Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> ScoringModelWithExpectedResultTestCases()
    {
        yield return [GetScoringModel(0, 0, 0, 0, 0, 0), 0];
        yield return [GetScoringModel(39, 0, 22, 16, 3, 0), 80];
        yield return [GetScoringModel(22, 1, 19, 17, 5, 1), 66];
        yield return [GetScoringModel(22, 2, 14, 5, 0, 0), 45];
        yield return [GetScoringModel(26, 6, 23, 14, 13, 20), 108];
    }

    private static TyrantsOfTheUnderdarkScoringModel GetScoringModel(
        byte controlSitesScore,
        byte totalControlSitesScore,
        byte troopsTrophyHallScore,
        byte deckValueScore,
        byte innerCircleDeckValueScore,
        byte victoryPointTokensScore)
    {
        return new TyrantsOfTheUnderdarkScoringModel
        {
            ControlSitesScore = controlSitesScore,
            TotalControlSitesScore = totalControlSitesScore,
            TroopsTrophyHallScore = troopsTrophyHallScore,
            DeckValueScore = deckValueScore,
            InnerCircleDeckValueScore = innerCircleDeckValueScore,
            VictoryPointTokensScore = victoryPointTokensScore,
        };
    }
}