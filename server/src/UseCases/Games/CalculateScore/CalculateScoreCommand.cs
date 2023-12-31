﻿using System;
using System.Text.Json;
using MediatR;

namespace BGS.UseCases.Games.CalculateScore;

public record CalculateScoreCommand(Guid GameId, JsonElement GameData) : IRequest<int>;