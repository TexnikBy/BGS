namespace BGS.Games.FiveTribes;

internal record FiveTribesScoringModel
{
    public byte GoldCoinsScore { get; init; }

    public byte YellowViziersScore { get; init; }

    public byte WhiteEldersScore { get; init; }

    public byte DjinnCardsScore { get; init; }

    public byte PalmTreesScore { get; init; }

    public byte PalacesScore { get; init; }

    public byte TilesScore { get; init; }

    public byte MerchandiseScore { get; init; }
}