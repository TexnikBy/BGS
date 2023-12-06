namespace BGS.Games.ClankCatacombs;

internal record ClankCatacombsScoringModel
{
    public bool isEscapedFromDepths { get; init; }

    public byte ArtefactsScore { get; init; }
    
    public byte AllTokensScore { get; init; }
    
    public byte GoldCoinsScore { get; init; }
    
    public byte DeckValueScore { get; init; }
}