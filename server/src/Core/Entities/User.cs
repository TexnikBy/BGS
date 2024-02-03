﻿using System;

namespace BGS.ApplicationCore.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string PasswordHash { get; set; }
}