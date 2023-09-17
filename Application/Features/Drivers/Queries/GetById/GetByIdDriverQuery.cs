using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Drivers.Queries.GetById;

public class GetByIdDriverQuery: IRequest<GetByIdDriverResponse>
{
    public int Id { get; set; }
    
    public class GetByIdDriverQueryHandler : IRequestHandler<GetByIdDriverQuery,GetByIdDriverResponse>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public GetByIdDriverQueryHandler(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdDriverResponse> Handle(GetByIdDriverQuery request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetAsync(
                predicate: x=>x.Id.Equals(request.Id),
                include: x=>x.Include(d=>d.Company),
                cancellationToken: cancellationToken,
                enableTracking: false
                );
            GetByIdDriverResponse response = _mapper.Map<GetByIdDriverResponse>(driver);
            
            return response;
        }
    }
    
}