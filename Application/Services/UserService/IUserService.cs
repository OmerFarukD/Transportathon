using System.Linq.Expressions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services.UserService;

public interface IUserService
{
    Task<User?> GetAsync(
        Expression<Func<AppUser, bool>> predicate,
        Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<Paginate<AppUser>> GetListAsync(Expression<Func<AppUser, bool>>? predicate = null,
        Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>>? orderBy = null,
        Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);
    
    Task<AppUser> AddAsync(AppUser user);
    Task<User> UpdateAsync(AppUser user);
    Task<User> DeleteAsync(AppUser user, bool permanent = false);
}