using System.Threading;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.SharedKernel;
using MediatR;

namespace BGS.UseCases.Games.CalculationDetails;

internal class CalculationDetailsRequestHandler : IRequestHandler<CalculationDetailsRequest, CalculationDetailsResponse>
{
    private readonly IRepository<Game> _gameRepository;

    public CalculationDetailsRequestHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<CalculationDetailsResponse> Handle(CalculationDetailsRequest request, CancellationToken cancellationToken)
    {
        var gameName = await _gameRepository.SingleOrDefaultAsync(new GetGameNameByIdSpecification(request.GameId));
        return new CalculationDetailsResponse(gameName);
    }
}