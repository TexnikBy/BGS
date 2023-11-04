namespace BGS.Games.BattleForRokugan;

internal record BattleForRokuganScoringModel
{
    public byte CountOfProvincialFlowers { get; init; }

    public byte CountOfFaceUpControlTokens { get; init; }

    public byte SecretObjectivePoints { get; init; }

    public byte CountOfControlledTerritories { get; init; }
}