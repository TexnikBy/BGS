using System;
using Ardalis.Specification;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Models;

namespace BGS.ApplicationCore.Games.Specifications;

public sealed class GameDetailsSpecification : SingleResultSpecification<Game, GameDetailsResponse>
{
    public GameDetailsSpecification(Guid gameId)
    {
        Query.Where(game => game.Id == gameId);
        Query.Select(game => new GameDetailsResponse
        {
            Name = game.Name
        });
    }
}