using System.Security.Cryptography;
using BGS.Api.ServiceInstallers.Interfaces;
using BGS.ApplicationCore.Entities;
using BGS.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BGS.Api.ServiceInstallers;

internal class JwtInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptionsSection = configuration.GetSection(nameof(JwtOptions));
        services.Configure<JwtOptions>(jwtOptionsSection);

        var jwtOptions = jwtOptionsSection.Get<JwtOptions>();
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = GetIssuerSigningKey(jwtOptions.PublicSigningKey),
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
        };

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = tokenValidationParameters;
        });

        services.AddIdentityCore<User>();
    }

    private static RsaSecurityKey GetIssuerSigningKey(string publicKey)
    {
        var rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey), out _);

        return new RsaSecurityKey(rsa);
    }
}