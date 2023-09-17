using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IDriverRepository : IAsyncRepository<Driver, int>, IRepository<Driver, int>
{
    
}