namespace BGS.Games.TyrantsOfTheUnderdark;

internal record TyrantsOfTheUnderdarkScoringModel
{
    public byte TrophyHall { get; init; }
    
    public byte Deck { get; init; }
    
    public byte InnerCircleDeck { get; init; }
    
    public byte Tokens { get; init; }
    
    public byte ControlSites { get; init; }
    
    public byte TotalControlSites { get; init; }
}