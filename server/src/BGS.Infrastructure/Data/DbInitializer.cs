using Microsoft.EntityFrameworkCore;

namespace BGS.Infrastructure.Data;

public class DbInitializer
{
    private readonly ApplicationDbContext _context;

    public DbInitializer(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Run()
    {
        _context.Database.Migrate();
    }
}