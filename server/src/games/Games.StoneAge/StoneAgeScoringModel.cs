using BGS.Games.Shared.Interfaces;

namespace BGS.Games.StoneAge;

public record StoneAgeScoringModel : IGameScoringModel<StoneAgeScoringModel>
{
    public short CurrentPoint { get; init; }

    public short CountOfResources { get; init; }

    public byte NumberOfFoodProduction { get; init; }

    public byte NumberOfFarmers { get; init; }

    public byte NumberOfTools { get; init; }

    public byte NumberOfToolMakers { get; init; }

    public byte NumberOfBuildings { get; init; }

    public byte NumberOfHutBuilders { get; init; }

    public byte NumberOfShamans { get; init; }

    public byte NumberOfPeople { get; init; }

    public List<byte> CollectionOfGreenCivilizationCards { get; init; } = [];

    public int TotalScore => CurrentPoint +
                             CountOfResources +
                             NumberOfFoodProduction * NumberOfFarmers +
                             NumberOfTools * NumberOfToolMakers +
                             NumberOfBuildings * NumberOfHutBuilders +
                             NumberOfPeople * NumberOfShamans +
                             CollectionOfGreenCivilizationCards.Select(count => count * count).Sum();

    private int VillageDevelopment => NumberOfTools +
                                      NumberOfPeople +
                                      NumberOfFoodProduction;

    public int CompareTo(StoneAgeScoringModel other)
    {
        if (TotalScore == other.TotalScore)
        {
            return VillageDevelopment - other.VillageDevelopment;
        }

        return TotalScore - other.TotalScore;
    }
}