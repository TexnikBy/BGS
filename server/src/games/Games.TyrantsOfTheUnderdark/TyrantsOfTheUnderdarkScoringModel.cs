namespace BGS.Games.TyrantsOfTheUnderdark;

internal record TyrantsOfTheUnderdarkScoringModel
{
    public byte ControlSitesScore { get; init; }
    
    public byte TotalControlSitesScore { get; init; }
    
    public byte TroopsTrophyHallScore { get; init; }
    
    public byte DeckValueScore { get; init; }
    
    public byte InnerCircleDeckValueScore { get; init; }
    
    public byte VictoryPointTokensScore { get; init; }
}