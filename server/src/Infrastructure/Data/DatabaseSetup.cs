using System;
using System.Threading.Tasks;
using BGS.ApplicationCore.Entities;
using BGS.ApplicationCore.Games.Constants;
using Microsoft.EntityFrameworkCore;

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
        if (await NoDataExistsAsync())
        {
            return;
        }

        await using var transaction = await _context.Database.BeginTransactionAsync();
        await SetupInitialDataAsync();
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    private Task<bool> NoDataExistsAsync() => _context.Set<Game>().AnyAsync();

    private async Task SetupInitialDataAsync()
    {
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