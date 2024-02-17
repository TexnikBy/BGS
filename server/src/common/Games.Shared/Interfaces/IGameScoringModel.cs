using System;

namespace BGS.Games.Shared.Interfaces;

public interface IGameScoringModel<in T> : IComparable<T>
{
    public int TotalScore { get; }
}