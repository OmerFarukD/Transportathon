using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TransportationRepository :EfRepositoryBase<Transportation,Guid,BaseDbContext>, ITransportationRepository
{
    public TransportationRepository(BaseDbContext context) : base(context)
    {
    }
}