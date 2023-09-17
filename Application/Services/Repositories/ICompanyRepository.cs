using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICompanyRepository : IAsyncRepository<Company, Guid>, IRepository<Company, Guid>
{
    
}