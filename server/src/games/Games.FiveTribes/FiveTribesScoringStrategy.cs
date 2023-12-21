using System.Text.Json;
using BGS.ApplicationCore.Games.CalculateScore;

namespace BGS.Games.FiveTribes;

internal class FiveTribesScoringStrategy : IGameScoringStrategy
{
    public int Calculate(JsonElement scoringData)
    {
        var model = scoringData.Deserialize<FiveTribesScoringModel>();

        return model.GoldCoinsScore +
           model.YellowViziersScore +
           model.WhiteEldersScore * 2 +
           model.DjinnCardsScore +
           model.PalmTreesScore * 3 +
           model.PalacesScore * 5 +
           model.TilesScore +
           model.MerchandiseScore;
    }
}