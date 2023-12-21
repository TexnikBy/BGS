using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BGS.SharedKernel.FileStorages;
using Microsoft.IdentityModel.Tokens;
using Supabase.Storage;
using FileOptions = Supabase.Storage.FileOptions;

namespace BGS.Infrastructure.FileStorages.Supabase;

internal class SupabaseStorage(SupabaseStorageSettings settings)
    : IFileStorage
{
    private readonly FileOptions _fileOptions = new() { Upsert = true };
    private readonly JwtSecurityTokenHandler _tokenHandler = new ();

    public async Task<string> Upload(FileModel model)
    {
        var client = CreateClient();
        await using var readStream = model.OpenReadStream();
        await using var memoryStream = new MemoryStream();
        await readStream.CopyToAsync(memoryStream);
        await client.From(settings.BucketId)
            .Upload(memoryStream.ToArray(), model.Name, _fileOptions);

        return client.From(settings.BucketId).GetPublicUrl(model.Name);
    }
    
    private Client CreateClient()
    {
        var headers = new Dictionary<string, string>
        {
            { "apikey", settings.ApiKey },
            { "authorization", $"Bearer {GenerateToken()}" }
        };

        return new Client(settings.Url, headers);
    }

    private string GenerateToken()
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSecret));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new List<Claim>
                {
                    new ("role", "authenticated"),
                }),
            SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        };

        return _tokenHandler.WriteToken(_tokenHandler.CreateToken(tokenDescriptor));
    }
}