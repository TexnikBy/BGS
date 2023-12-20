namespace BGS.Games.ClankCatacombs;

internal record ClankCatacombsScoringModel
{
    public bool IsEscapedFromDepths { get; init; }

    public byte ArtefactsScore { get; init; }
    
    public byte TokensScore { get; init; }
    
    public byte GoldCoinsScore { get; init; }
    
    public byte DeckValueScore { get; init; }
}