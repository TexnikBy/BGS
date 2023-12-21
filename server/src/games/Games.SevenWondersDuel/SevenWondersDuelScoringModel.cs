namespace BGS.Games.SevenWondersDuel;

internal record SevenWondersDuelScoringModel
{
    public byte BlueBuildingsScore { get; init; }

    public byte GreenBuildingsScore { get; init; }

    public byte YellowBuildingsScore { get; init; }

    public byte PurpleBuildingsScore { get; init; }

    public byte WondersScore { get; init; }

    public byte ProgressScore { get; init; }

    public byte CoinsScore { get; init; }

    public byte MilitaryScore { get; init; }

    public bool IsWonViaMilitarySupremacy { get; init; }

    public bool IsWonViaScientificSupremacy { get; init; }
}