using System.Text.Json;
using BGS.ApplicationCore.Games.CalculateScore;

namespace BGS.Games.StoneAge;

internal class StoneAgeScoringStrategy : IGameScoringStrategy
{
    public int Calculate(JsonElement scoringData)
    {
        var model = scoringData.Deserialize<StoneAgeScoringModel>();

        return model.CurrentPoint +
               model.CountOfResources +
               model.NumberOfFoodProduction * model.NumberOfFarmers +
               model.NumberOfTools * model.NumberOfToolMakers +
               model.NumberOfBuildings * model.NumberOfHutBuilders +
               model.NumberOfPeople * model.NumberOfShamans +
               model.CollectionOfGreenCivilizationCards.Select(count => count * count).Sum();
    }
}