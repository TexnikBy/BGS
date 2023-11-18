using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BGS.ApplicationCore.Identity.Interfaces;
using BGS.Infrastructure.Identity.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BGS.Infrastructure.Identity;

internal class AccessTokenGenerator(
        IOptions<JwtOptions> authenticationOptions,
        IUserClaimsProvider userClaimsProvider,
        SecurityTokenHandler tokenHandler)
    : IAccessTokenGenerator
{
    private readonly JwtOptions _jwtOptions = authenticationOptions.Value;

    public async Task<string> Generate(string userName)
    {
        var claims = await userClaimsProvider.Get(userName);
        var tokenDescriptor = CreateSecurityTokenDescriptor(claims);
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private SecurityTokenDescriptor CreateSecurityTokenDescriptor(IEnumerable<Claim> claims)
    {
        var currentDateTimeAsUtc = DateTime.UtcNow;

        return new SecurityTokenDescriptor
        {
            Issuer = _jwtOptions.Issuer,
            NotBefore = currentDateTimeAsUtc,
            IssuedAt = currentDateTimeAsUtc,
            Subject = new ClaimsIdentity(claims),
            Expires = currentDateTimeAsUtc.Add(_jwtOptions.AccessTokenLifetime),
            SigningCredentials = GetSigningCredentials(),
        };
    }

    private SigningCredentials GetSigningCredentials()
    {
        var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(Convert.FromBase64String(_jwtOptions.PrivateSigningKey), out _);

        return new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);
    }
}