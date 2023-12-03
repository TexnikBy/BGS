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
        yield return new object[] { GetTyrantsOfTheUnderdarkScoringJsonElement(1, 1, 1, 1, 1, 1), 6 };
        yield return new object[] { GetTyrantsOfTheUnderdarkScoringJsonElement(10, 0, 11, 7, 9, 2), 39 };
    }

    private static JsonElement GetTyrantsOfTheUnderdarkScoringJsonElement(
        byte trophyHall,
        byte deck,
        byte innerCircleDeck,
        byte tokens,
        byte controlSites,
        byte totalControlSites)
    {
        return JsonSerializer.SerializeToElement(
            new TyrantsOfTheUnderdarkScoringModel
            {
                TrophyHall = trophyHall,
                Deck = deck,
                InnerCircleDeck = innerCircleDeck,
                Tokens = tokens,
                ControlSites = controlSites,
                TotalControlSites = totalControlSites,
            });
    }
}