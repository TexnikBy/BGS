using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Specifications;
using BGS.ApplicationCore.Interfaces;
using BGS.SharedKernel;

namespace BGS.ApplicationCore.Validators;

public class GameDuplicationChecker(IRepository<Game> gameRepository) : IGameDuplicationChecker
{
    public Task<bool> Check(string gameName)
    {
        return gameRepository.AnyAsync(new GameByNameSpecification(gameName));
    }
}