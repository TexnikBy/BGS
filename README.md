# BGS
BGS - The application for scoring in a board game

### Configuration for development
`appsettings.Development.json`
```
{
  "AllowedHosts": "*",
  "ConnectionStrings": {
    // Customizing the database connection string
    "DefaultConnection": "Server=localhost;Port=5432;Database=BGS;UserId=postgres;Password=set-up-your-password"
  },
  "JwtOptions": {
    // Any string
    "Issuer": "YourIssuer",
    // Token lifetime setting
    "AccessTokenLifetime": "00:02:00",
    // You can generate a public and private signature key here - https://travistidwell.com/jsencrypt/demo/
    "PublicSigningKey": "",
    "PrivateSigningKey": ""
  }
}
```

### Create database migration
Go to `src/Api` from BGS folder `cd src/Api` after it run command:
```
dotnet ef migrations add NameOfMigration -c ApplicationDbContext -p ../Infrastructure/Infrastructure.csproj -s Api.csproj -o Data/Migrations
```