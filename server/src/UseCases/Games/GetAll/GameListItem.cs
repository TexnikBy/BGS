using System;

namespace BGS.UseCases.Games.GetAll;

public record GameListItem(Guid Id, string Name, string PosterUrl);