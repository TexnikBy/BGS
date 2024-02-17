using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace BGS.Games.BattleForRokugan.Tests.BattleForRokuganScoringModelTests;

public class TotalScoreTests
{
    [Theory]
    [MemberData(nameof(ScoringModelWithExpectedResultTestCases))]
    public void TotalScoreShouldBeEqualExpectedResult(BattleForRokuganScoringModel model, int expectedResult)
    {
        // Arrange & Act & Assert
        model.TotalScore.Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> ScoringModelWithExpectedResultTestCases()
    {
        yield return [GetScoringModel(0, 0, 0, 0), 0];
        yield return [GetScoringModel(0, 0, 6, 0), 6];
        yield return [GetScoringModel(10, 3, 6, 0), 19];
        yield return [GetScoringModel(8, 6, 0, 2), 24];
        yield return [GetScoringModel(13, 9, 5, 3), 42];
    }

    private static BattleForRokuganScoringModel GetScoringModel(
        byte countOfProvincialFlowers,
        byte countOfFaceUpControlTokens,
        byte secretObjectivePoints,
        byte countOfControlledTerritories)
    {
        return new BattleForRokuganScoringModel
        {
            CountOfProvincialFlowers = countOfProvincialFlowers,
            CountOfFaceUpControlTokens = countOfFaceUpControlTokens,
            SecretObjectivePoints = secretObjectivePoints,
            CountOfControlledRegions = countOfControlledTerritories,
        };
    }
}