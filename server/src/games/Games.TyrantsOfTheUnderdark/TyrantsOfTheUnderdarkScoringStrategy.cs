using BGS.Games.Shared;

namespace BGS.Games.TyrantsOfTheUnderdark;

internal class TyrantsOfTheUnderdarkScoringStrategy : BaseGameCalculator<TyrantsOfTheUnderdarkScoringModel>
{
    protected override int CalculateTotalScore(TyrantsOfTheUnderdarkScoringModel gameData)
    {
        return gameData.ControlSitesScore +
               gameData.TotalControlSitesScore * 2 +
               gameData.TroopsTrophyHallScore +
               gameData.DeckValueScore +
               gameData.InnerCircleDeckValueScore +
               gameData.VictoryPointTokensScore;
    }
}