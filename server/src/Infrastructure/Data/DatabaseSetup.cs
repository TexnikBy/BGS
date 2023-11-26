using System;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BGS.Infrastructure.Data;

public class DatabaseSetup(ApplicationDbContext context)
{
    public async Task SetupAsync()
    {
        await context.Database.MigrateAsync();
        await ReloadTypes();
        if (await NoDataExistsAsync())
        {
            return;
        }

        await using var transaction = await context.Database.BeginTransactionAsync();
        await SetupInitialDataAsync();
        await context.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    private async Task ReloadTypes()
    {
        if (context.Database.GetDbConnection() is NpgsqlConnection npgsqlConnection)
        {
            await npgsqlConnection.OpenAsync();
            await npgsqlConnection.ReloadTypesAsync();
        }
    }

    private Task<bool> NoDataExistsAsync() => context.Set<Game>().AnyAsync();

    private async Task SetupInitialDataAsync()
    {
        await context.Set<User>().AddAsync(new User
        {
            Id = Guid.NewGuid(),
            Name = "Admin",
        });
        await context.Set<Game>().AddRangeAsync(
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Stone Age",
                Key = "StoneAge",
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Battle for Rokugan",
                Key = "BattleForRokugan",
            });
    }
}