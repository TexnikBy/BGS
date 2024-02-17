namespace BGS.ApplicationCore.Games.CalculateScore;

public record GameCalculationResultModel
{
    public int Place { get; init; }

    public byte PlayerNumber { get; init; }

    public string PlayerName { get; init; }

    public int TotalScore { get; init; }
}