using System;
using BGS.SharedKernel.Results;
using MediatR;

namespace BGS.UseCases.Games.Save;

public record SaveGameCommand(Guid? Id, string Name, string Key) : IRequest<Result>;