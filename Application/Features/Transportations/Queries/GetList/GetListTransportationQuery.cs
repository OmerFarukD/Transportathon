using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Transportations.Queries.GetList;

public class GetListTransportationQuery :IRequest<GetListResponse<GetListTransportationListItemDto>>,ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    
    public string CacheKey => $"GetListTransportationQuery({PageRequest.PageIndex},{PageRequest.PageSize})";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetTransportations";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListTransportationQueryHandler : IRequestHandler<GetListTransportationQuery,GetListResponse<GetListTransportationListItemDto>>
    {
        private readonly ITransportationRepository _transportationRepository;
        private readonly IMapper _mapper;

        public GetListTransportationQueryHandler(ITransportationRepository transportationRepository, IMapper mapper)
        {
            _transportationRepository = transportationRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListTransportationListItemDto>> Handle(GetListTransportationQuery request, CancellationToken cancellationToken)
        {
            Paginate<Transportation> trasportations = await _transportationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: x => x.Include(x => x.AppUser),
                cancellationToken: cancellationToken

            );

            GetListResponse<GetListTransportationListItemDto> response =
                _mapper.Map<GetListResponse<GetListTransportationListItemDto>>(trasportations);


            return response;

        }
    }
    
}