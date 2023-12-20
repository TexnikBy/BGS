using System.Collections.Generic;
using System.Text.Json;
using Autofac.Extras.Moq;
using FluentAssertions;
using Xunit;

namespace BGS.Games.SevenWondersDuel.Tests.SevenWondersDuelScoringStrategyTests;

public class CalculateTests
{
    private readonly SevenWondersDuelScoringStrategy _sut =
        AutoMock.GetLoose().Create<SevenWondersDuelScoringStrategy>();

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
        yield return new object[] { GetSevenWondersDuelScoringJsonElement(0, 0, 0, 0, 0, 0, 0, 0, false, false), 0 };
        yield return new object[] { GetSevenWondersDuelScoringJsonElement(3, 14, 7, 23, 9, 15, 9, 2, false, false), 76 };
        yield return new object[] { GetSevenWondersDuelScoringJsonElement(2, 13, 7, 21, 9, 14, 8, 2, true, false), 0 };
        yield return new object[] { GetSevenWondersDuelScoringJsonElement(2, 13, 7, 21, 9, 14, 8, 2, false, true), 0 };
    }

    private static JsonElement GetSevenWondersDuelScoringJsonElement(
        byte blueBuildingsScore,
        byte greenBuildingsScore,
        byte yellowBuildingsScore,
        byte purpleBuildingsScore,
        byte wondersScore,
        byte progressScore,
        byte coinsScore,
        byte militaryScore,
        bool isWonViaMilitarySupremacy,
        bool isWonViaScientificSupremacy)
    {
        return JsonSerializer.SerializeToElement(
            new SevenWondersDuelScoringModel
            {
                BlueBuildingsScore = blueBuildingsScore,
                GreenBuildingsScore = greenBuildingsScore,             
                YellowBuildingsScore = yellowBuildingsScore,
                PurpleBuildingsScore = purpleBuildingsScore,
                WondersScore = wondersScore,
                ProgressScore = progressScore,
                CoinsScore = coinsScore,
                MilitaryScore = militaryScore,
                IsWonViaMilitarySupremacy = isWonViaMilitarySupremacy,
                IsWonViaScientificSupremacy = isWonViaScientificSupremacy,
            });
    }
}