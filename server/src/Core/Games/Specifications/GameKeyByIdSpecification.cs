using System;
using Ardalis.Specification;
using BGS.ApplicationCore.Entities;

namespace BGS.ApplicationCore.Games.Specifications;

public sealed class GameKeyByIdSpecification : SingleResultSpecification<Game, string>
{
    public GameKeyByIdSpecification(Guid gameId)
    {
        Query.Where(game => game.Id == gameId);
        Query.Select(game => game.Key);
    }
}