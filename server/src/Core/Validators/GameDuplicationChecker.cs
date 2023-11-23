using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Interfaces;
using BGS.ApplicationCore.Specifications;
using BGS.SharedKernel;

namespace BGS.ApplicationCore.Validators;

public class GameDuplicationChecker(IRepository<Game> gameRepository) : IGameDuplicationChecker
{
    public async Task<bool> Check(string gameName)
    {
        return await gameRepository.AnyAsync(new GameNameDuplicationsSpecification(gameName));
    }
}