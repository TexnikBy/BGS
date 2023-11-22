using Ardalis.Specification;
using BGS.ApplicationCore.Entities;

namespace BGS.ApplicationCore.Specifications;

public sealed class GameNameDuplicationsSpecification : SingleResultSpecification<Game, bool>
{
    public GameNameDuplicationsSpecification(string gameName)
    {
        Query.Where(game => string.Equals(game.Name.ToUpper(), gameName.ToUpper()));
    }
}
