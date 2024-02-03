using System.Text.Json;

namespace BGS.ApplicationCore.Games.CalculateScore;

public record PlayerCalculationModel
{
    public byte PlayerNumber { get; init; }

    public string PlayerName { get; init; }

    public JsonElement GameData { get; init; }
}