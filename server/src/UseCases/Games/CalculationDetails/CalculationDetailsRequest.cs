using MediatR;

namespace BGS.UseCases.Games.CalculationDetails;

public record CalculationDetailsRequest(int GameId) : IRequest<CalculationDetailsResponse>;