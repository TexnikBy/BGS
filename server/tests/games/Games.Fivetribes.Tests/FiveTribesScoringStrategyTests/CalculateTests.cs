using System.Collections.Generic;
using System.Text.Json;
using Autofac.Extras.Moq;
using FluentAssertions;
using Xunit;

namespace BGS.Games.FiveTribes.Tests.FiveTribesScoringStrategyTests;

public class CalculateTests
{
    private readonly FiveTribesScoringStrategy _sut =
        AutoMock.GetLoose().Create<FiveTribesScoringStrategy>();

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
        yield return new object[] { GetFiveTribesScoringJsonElement(0, 0, 0, 0, 0, 0, 0, 0), 0 };
        yield return new object[] { GetFiveTribesScoringJsonElement(16, 5, 4, 6, 2, 2, 48, 21), 120 };
    }

    private static JsonElement GetFiveTribesScoringJsonElement(
        byte goldCoinsScore,
        byte yellowViziersScore,
        byte whiteEldersScore,
        byte djinnCardsScore,
        byte palmTreesScore,
        byte palacesScore,
        byte tilesScore,
        byte merchandiseScore)
    {
        return JsonSerializer.SerializeToElement(
            new FiveTribesScoringModel
            {
                GoldCoinsScore = goldCoinsScore,
                YellowViziersScore = yellowViziersScore,
                WhiteEldersScore = whiteEldersScore,
                DjinnCardsScore = djinnCardsScore,
                PalmTreesScore = palmTreesScore,
                PalacesScore = palacesScore,
                TilesScore = tilesScore,
                MerchandiseScore = merchandiseScore,
            });
    }
}