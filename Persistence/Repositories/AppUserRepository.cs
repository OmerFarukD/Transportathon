using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AppUserRepository : EfRepositoryBase<AppUser,int,BaseDbContext>,IAppUserRepository
{
    public AppUserRepository(BaseDbContext context) : base(context)
    {
    }
}