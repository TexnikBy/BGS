using Ardalis.Specification;
using BGS.ApplicationCore.Entities;

namespace BGS.UseCases.Games.GetAll;

public sealed class GameListItemSpecification : Specification<Game, GameListItem>
{
    public GameListItemSpecification()
    {
        Query.Select(g => new GameListItem(g.Id, g.Name));
    }
}