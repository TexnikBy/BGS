using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Interfaces;
using BGS.ApplicationCore.Games.Specifications;
using BGS.SharedKernel;

namespace BGS.ApplicationCore.Games.Validators;

public class GameDuplicationChecker(IRepository<Game> gameRepository) : IGameDuplicationChecker
{
    public Task<bool> Check(string gameName)
    {
        return gameRepository.AnyAsync(new GameByNameSpecification(gameName));
    }
}