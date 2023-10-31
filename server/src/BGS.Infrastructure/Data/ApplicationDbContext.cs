using BGS.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BGS.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
    
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }
}