using Ardalis.Specification;
using BGS.ApplicationCore.Entities;

namespace BGS.ApplicationCore.Games.Specifications;

public sealed class GameByNameSpecification : SingleResultSpecification<Game, bool>
{
    public GameByNameSpecification(string gameName)
    {
        Query.Where(game => string.Equals(game.Name, gameName));
    }
}
