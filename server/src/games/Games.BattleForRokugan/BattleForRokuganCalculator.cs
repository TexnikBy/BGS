using BGS.Games.Shared;

namespace BGS.Games.BattleForRokugan;

internal class BattleForRokuganCalculator : BaseGameCalculator<BattleForRokuganScoringModel>
{
    protected override int CalculateTotalScore(BattleForRokuganScoringModel gameData)
    {
        return gameData.CountOfProvincialFlowers +
               gameData.CountOfFaceUpControlTokens +
               gameData.SecretObjectivePoints +
               gameData.CountOfControlledTerritories * 5;
    }
}