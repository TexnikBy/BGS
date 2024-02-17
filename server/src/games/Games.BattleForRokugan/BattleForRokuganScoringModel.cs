using BGS.Games.Shared.Interfaces;

namespace BGS.Games.BattleForRokugan;

public record BattleForRokuganScoringModel : IGameScoringModel<BattleForRokuganScoringModel>
{
    public byte CountOfProvincialFlowers { get; init; }

    public byte CountOfFaceUpControlTokens { get; init; }

    public byte SecretObjectivePoints { get; init; }

    public byte CountOfControlledRegions { get; init; }

    public byte CountOfControlledProvinces { get; init; }

    public int TotalScore => CountOfProvincialFlowers +
                             CountOfFaceUpControlTokens +
                             SecretObjectivePoints +
                             CountOfControlledRegions * 5;
    
    public int CompareTo(BattleForRokuganScoringModel other)
    {
        if (TotalScore != other.TotalScore)
        {
            return TotalScore - other.TotalScore;
        }

        if (CountOfControlledRegions != other.CountOfControlledRegions)
        {
            return CountOfControlledRegions - other.CountOfControlledRegions;
        }

        return CountOfControlledProvinces - other.CountOfControlledProvinces;
    }
}