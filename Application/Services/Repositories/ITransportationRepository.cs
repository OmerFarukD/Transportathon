using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ITransportationRepository : IAsyncRepository<Transportation, Guid>, IRepository<Transportation, Guid>
{
    
}