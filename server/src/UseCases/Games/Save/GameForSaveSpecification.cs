using System;
using Ardalis.Specification;
using BGS.ApplicationCore.Entities;

namespace BGS.UseCases.Games.Save;

internal sealed class GameForSaveSpecification : SingleResultSpecification<Game, bool>
{
    public GameForSaveSpecification(Guid? id, string name)
    {
        Query.Where(game => string.Equals(game.Name, name));
        if (id.HasValue)
        {
            Query.Where(game => game.Id != id);
        }
    }
}
