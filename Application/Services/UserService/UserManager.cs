using System.Linq.Expressions;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services.UserService;

public class UserManager : IUserService
{
    private readonly IAppUserRepository _userRepository;
    private readonly UserBusinessRules _userBusinessRules;

    public UserManager(IAppUserRepository userRepository, UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<User?> GetAsync(
        Expression<Func<AppUser, bool>> predicate,
        Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        User? user = await _userRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return user;
    }

    public async Task<Paginate<AppUser>> GetListAsync(Expression<Func<AppUser, bool>>? predicate = null,
        Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>>? orderBy = null,
        Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        Paginate<AppUser> userList = await _userRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userList;
    }

    public async Task<AppUser> AddAsync(AppUser user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(user.Email);

        AppUser addedUser = await _userRepository.AddAsync(user);

        return addedUser;
    }

    public async Task<User> UpdateAsync(AppUser user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user.Id, user.Email);

        User updatedUser = await _userRepository.UpdateAsync(user);

        return updatedUser;
    }

    public async Task<User> DeleteAsync(AppUser user, bool permanent = false)
    {
        User deletedUser = await _userRepository.DeleteAsync(user);

        return deletedUser;
    }
}