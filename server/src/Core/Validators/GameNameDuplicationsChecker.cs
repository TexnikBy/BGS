using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Interfaces;
using BGS.SharedKernel;

namespace BGS.ApplicationCore.Validators;

public class GameNameDuplicationsChecker(IRepository<Game> gameRepository) : IGameNameDuplicationsChecker
{
    public async Task<bool> Check(string gameName, CancellationToken cancellationToken)
    {
        return await gameRepository.AnyAsync(
            new GameNameDuplicationsSpecification(gameName),
            cancellationToken);
    }
}