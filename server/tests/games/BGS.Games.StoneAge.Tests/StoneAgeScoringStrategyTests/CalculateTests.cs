using System.Collections.Generic;
using System.Text.Json;
using Autofac.Extras.Moq;
using FluentAssertions;
using Xunit;

namespace BGS.Games.StoneAge.Tests.StoneAgeScoringStrategyTests;

public class CalculateTests
{
    private readonly StoneAgeScoringStrategy _sut;

    public CalculateTests()
    {
        _sut = AutoMock.GetLoose().Create<StoneAgeScoringStrategy>();
    }

    [Theory]
    [MemberData(nameof(ScoringDataWithExpectedResultTestCases))]
    public void ShouldCalculateCorrectly(JsonElement scoringData, int expectedResult)
    {
        var result = _sut.Calculate(scoringData);

        result.Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> ScoringDataWithExpectedResultTestCases()
    {
        yield return new object[] { GetStoneAgeScoringJsonElement(79, 0, 8, 2, 9, 6, 6, 4, 3, 7, 6, 3), 239 };
        yield return new object[] { GetStoneAgeScoringJsonElement(97, 9, 8, 1, 6, 1, 7, 3, 4, 7, 4, 1), 186 };
        yield return new object[] { GetStoneAgeScoringJsonElement(101, 4, 9, 2, 6, 3, 5, 8, 4, 9, 8), 281 };
        yield return new object[] { GetStoneAgeScoringJsonElement(61, 9, 5, 5, 8, 5, 5, 1, 3, 8, 8), 228 };
        yield return new object[] { GetStoneAgeScoringJsonElement(78, 1, 7, 6, 5, 4, 5, 5, 1, 8, 5, 2), 203 };
        yield return new object[] { GetStoneAgeScoringJsonElement(84, 11, 8, 1, 7, 4, 4, 4, 6, 8, 6, 2), 235 };
        yield return new object[] { GetStoneAgeScoringJsonElement(104, 1, 6, 1, 5, 5, 5, 6, 6, 8, 0), 214 };
        yield return new object[] { GetStoneAgeScoringJsonElement(57, 2, 9, 4, 1, 1, 4, 3, 0, 8, 7, 1), 158 };
        yield return new object[] { GetStoneAgeScoringJsonElement(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), 0 };
    }

    private static JsonElement GetStoneAgeScoringJsonElement(
        short currentPoint,
        short countOfResources,
        byte numberOfFoodProduction,
        byte numberOfFarmers,
        byte numberOfTools,
        byte numberOfToolMakers,
        byte numberOfBuildings,
        byte numberOfHutBuilders,
        byte numberOfShamens,
        byte numberOfPeople,
        byte countOfFirstCollectionOfGreenCivilizationCards,
        byte? countOfSecondCollectionOfGreenCivilizationCards = null)
    {
        var collectionOfGreenCivilizationCards = new List<byte> { countOfFirstCollectionOfGreenCivilizationCards };
        if (countOfSecondCollectionOfGreenCivilizationCards.HasValue)
        {
            collectionOfGreenCivilizationCards.Add(countOfSecondCollectionOfGreenCivilizationCards.Value);
        }

        return JsonSerializer.SerializeToElement(
            new StoneAgeScoringModel
            {
                CurrentPoint = currentPoint,
                CountOfResources = countOfResources,
                NumberOfFoodProduction = numberOfFoodProduction,
                NumberOfFarmers = numberOfFarmers,
                NumberOfTools = numberOfTools,
                NumberOfToolMakers = numberOfToolMakers,
                NumberOfBuildings = numberOfBuildings,
                NumberOfHutBuilders = numberOfHutBuilders,
                NumberOfShamens = numberOfShamens,
                NumberOfPeople = numberOfPeople,
                CollectionOfGreenCivilizationCards = collectionOfGreenCivilizationCards,
            });
    }
}