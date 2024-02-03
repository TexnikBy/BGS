using Ardalis.Specification;
using BGS.ApplicationCore.Entities;

namespace BGS.UseCases.Games.CalculateScore;

public sealed class GameKeyByIdSpecification : SingleResultSpecification<Game, string>
{
    public GameKeyByIdSpecification(int gameId)
    {
        Query.Where(game => game.Id == gameId);
        Query.Select(game => game.Key);
    }
}