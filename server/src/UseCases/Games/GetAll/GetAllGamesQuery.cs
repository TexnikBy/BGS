﻿using System.Collections.Generic;
using BGS.ApplicationCore.Games.Models;
using MediatR;

namespace BGS.UseCases.Games.GetAll;

public record GetAllGamesQuery : IRequest<List<GameListItem>>;