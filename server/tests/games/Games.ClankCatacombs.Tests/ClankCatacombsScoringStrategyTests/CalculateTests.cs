using System.Collections.Generic;
using System.Text.Json;
using Autofac.Extras.Moq;
using FluentAssertions;
using Xunit;

namespace BGS.Games.ClankCatacombs.Tests.ClankCatacombsScoringStrategyTests;

public class CalculateTests
{
    private readonly ClankCatacombsScoringStrategy _sut =
        AutoMock.GetLoose().Create<ClankCatacombsScoringStrategy>();

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
        yield return new object[] { GetClankCatacombsScoringJsonElement(true, 12, 45, 21, 8), 86 };
        yield return new object[] { GetClankCatacombsScoringJsonElement(true, 0, 0, 0, 0), 0 };
        yield return new object[] { GetClankCatacombsScoringJsonElement(false, 12, 45, 21, 8), 0 };
        yield return new object[] { GetClankCatacombsScoringJsonElement(false, 0, 0, 0, 0), 0 };
    }

    private static JsonElement GetClankCatacombsScoringJsonElement(
        bool isEscapedFromDepths,
        byte artefactsScore,
        byte allTokensScore,
        byte goldCoinsScore,
        byte deckValueScore)
    {
        return JsonSerializer.SerializeToElement(
            new ClankCatacombsScoringModel
            {
                isEscapedFromDepths = isEscapedFromDepths,
                ArtefactsScore = artefactsScore,
                AllTokensScore = allTokensScore,
                GoldCoinsScore = goldCoinsScore,
                DeckValueScore = deckValueScore,
            });
    }
}