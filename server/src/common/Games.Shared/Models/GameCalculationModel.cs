using BGS.Games.Shared.Interfaces;

namespace BGS.Games.Shared.Models;

public record GameCalculationModel<T> where T : IGameScoringModel<T>
{
    public byte PlayerNumber { get; init; }

    public string PlayerName { get; init; }

    public T ScoringModel { get; init; }
}