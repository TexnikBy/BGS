using Ardalis.Specification;
using BGS.ApplicationCore.Entities;

namespace BGS.Infrastructure.Identity.Specificaitons;

internal sealed class UserByNameSpecification : SingleResultSpecification<User>
{
    public UserByNameSpecification(string userName)
    {
        Query.Where(u => u.Name == userName);
    }
}