using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Drivers.Queries.GetList;

public class GetListDriverQuery : IRequest<GetListResponse<GetListDriverListItemDto>>,ICachableRequest
{
    public PageRequest PageRequest { get; set; } = new();
    public string CacheKey => $"GetListDriverQuery({PageRequest.PageIndex},{PageRequest.PageSize})";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetDrivers";
    public TimeSpan? SlidingExpiration { get; }
    
    
    public class GetListDriverQueryHandler : IRequestHandler<GetListDriverQuery,GetListResponse<GetListDriverListItemDto>>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public GetListDriverQueryHandler(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDriverListItemDto>> Handle(GetListDriverQuery request, CancellationToken cancellationToken)
        {
            Paginate<Driver> drivers = await _driverRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                enableTracking: false,
                orderBy: x=>x.OrderBy(d=>d.Name),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDriverListItemDto> response =
                _mapper.Map<GetListResponse<GetListDriverListItemDto>>(drivers);

            return response;
        }
    }
    
}