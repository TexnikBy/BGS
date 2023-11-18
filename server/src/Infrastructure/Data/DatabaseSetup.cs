using System;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Constants;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BGS.Infrastructure.Data;

public class DatabaseSetup
{
    private readonly ApplicationDbContext _context;

    public DatabaseSetup(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SetupAsync()
    {
        await _context.Database.MigrateAsync();
        await ReloadTypes();
        if (await NoDataExistsAsync())
        {
            return;
        }

        await using var transaction = await _context.Database.BeginTransactionAsync();
        await SetupInitialDataAsync();
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    private async Task ReloadTypes()
    {
        if (_context.Database.GetDbConnection() is NpgsqlConnection npgsqlConnection)
        {
            await npgsqlConnection.OpenAsync();
            await npgsqlConnection.ReloadTypesAsync();
        }
    }

    private Task<bool> NoDataExistsAsync() => _context.Set<Game>().AnyAsync();

    private async Task SetupInitialDataAsync()
    {
        await _context.Set<User>().AddAsync(new User
        {
            Id = Guid.NewGuid(),
            Name = "Admin",
        });
        await _context.Set<Game>().AddRangeAsync(
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Stone Age",
                Key = GameKeys.StoneAge,
            },
            new Game
            {
                Id = Guid.NewGuid(),
                Name = "Battle for Rokugan",
                Key = GameKeys.BattleForRokugan,
            });
    }
}