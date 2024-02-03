using Ardalis.Specification.EntityFrameworkCore;
using BGS.SharedKernel;

namespace BGS.Infrastructure.Data;

public class EntityFrameworkCoreRepository<T> : RepositoryBase<T>, IRepository<T>
    where T : class
{
    public EntityFrameworkCoreRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}