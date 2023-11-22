using System;

namespace BGS.Infrastructure.Identity;

public record JwtOptions
{
    public string Issuer { get; init; }

    public string PublicSigningKey { get; init; }

    public string PrivateSigningKey { get; init; }

    public TimeSpan AccessTokenLifetime { get; init; }
}