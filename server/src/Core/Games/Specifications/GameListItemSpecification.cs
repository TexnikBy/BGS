using Ardalis.Specification;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Models;

namespace BGS.ApplicationCore.Games.Specifications;

public sealed class GameListItemSpecification : Specification<Game, GameListItem>
{
    public GameListItemSpecification()
    {
        Query.Select(g => new GameListItem(g.Id, g.Name));
    }
}