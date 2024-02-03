using BGS.Games.Shared;

namespace BGS.Games.StoneAge;

internal class StoneAgeCalculator : BaseGameCalculator<StoneAgeScoringModel>
{
    protected override int CalculateTotalScore(StoneAgeScoringModel gameData)
    {
        return gameData.CurrentPoint +
               gameData.CountOfResources +
               gameData.NumberOfFoodProduction * gameData.NumberOfFarmers +
               gameData.NumberOfTools * gameData.NumberOfToolMakers +
               gameData.NumberOfBuildings * gameData.NumberOfHutBuilders +
               gameData.NumberOfPeople * gameData.NumberOfShamans +
               gameData.CollectionOfGreenCivilizationCards.Select(count => count * count).Sum();
    }
}