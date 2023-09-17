using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DriverRepository : EfRepositoryBase<Driver,int,BaseDbContext>, IDriverRepository
{
    public DriverRepository(BaseDbContext context) : base(context)
    {
    }
}