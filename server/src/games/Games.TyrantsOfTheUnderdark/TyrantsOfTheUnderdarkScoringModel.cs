using BGS.Games.Shared.Interfaces;

namespace BGS.Games.TyrantsOfTheUnderdark;

public record TyrantsOfTheUnderdarkScoringModel : IGameScoringModel<TyrantsOfTheUnderdarkScoringModel>
{
    public byte ControlSitesScore { get; init; }
    
    public byte TotalControlSitesScore { get; init; }
    
    public byte TroopsTrophyHallScore { get; init; }
    
    public byte DeckValueScore { get; init; }
    
    public byte InnerCircleDeckValueScore { get; init; }
    
    public byte VictoryPointTokensScore { get; init; }

    public int TotalScore => ControlSitesScore +
                             TotalControlSitesScore * 2 +
                             TroopsTrophyHallScore +
                             DeckValueScore +
                             InnerCircleDeckValueScore +
                             VictoryPointTokensScore;
    
    
    public int CompareTo(TyrantsOfTheUnderdarkScoringModel other)
    {
        return TotalScore - other.TotalScore;
    }
}