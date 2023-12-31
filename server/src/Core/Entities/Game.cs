﻿using BGS.SharedKernel;

namespace BGS.ApplicationCore.Entities;

public class Game : BaseEntity
{
    public string Name { get; set; }

    public string Key { get; set; }

    public string PosterUrl { get; set; }
}