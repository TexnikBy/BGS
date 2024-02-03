namespace BGS.ApplicationCore.Games.CalculateScore;

public record GameCalculationResultModel
{
    public byte PlayerNumber { get; init; }

    public string PlayerName { get; init; }

    public int TotalScore { get; init; }
}