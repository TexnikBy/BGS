namespace BGS.Games.StoneAge;

public record StoneAgeScoringModel
{
    public short CurrentPoint { get; init; }

    public short CountOfResources { get; init; }

    public byte NumberOfFoodProduction { get; init; }

    public byte NumberOfFarmers { get; init; }

    public byte NumberOfTools { get; init; }

    public byte NumberOfToolMakers { get; init; }

    public byte NumberOfBuildings { get; init; }

    public byte NumberOfHutBuilders { get; init; }

    public byte NumberOfShamens { get; init; }

    public byte NumberOfPeople { get; init; }

    public List<byte> CollectionOfGreenCivilizationCards { get; init; }
}