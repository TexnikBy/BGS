using Ardalis.Specification;
using BGS.ApplicationCore.Entities;

namespace BGS.UseCases.Games.CalculationDetails;

internal sealed class GetGameNameByIdSpecification : SingleResultSpecification<Game, string>
{
    public GetGameNameByIdSpecification(int gameId)
    {
        Query.Where(g => g.Id == gameId);
        Query.Select(g => g.Name);
    }
}