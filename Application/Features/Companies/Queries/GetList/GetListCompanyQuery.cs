using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Queries.GetList;

public class GetListCompanyQuery : IRequest<GetListResponse<GetListCompanyListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public string CacheKey => $"GetListCompanyQuery({PageRequest.PageIndex},{PageRequest.PageSize})";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetCompanies";
    public TimeSpan? SlidingExpiration { get; }
    
    
    public class GetListCompanyQueryHandler : IRequestHandler<GetListCompanyQuery,GetListResponse<GetListCompanyListItemDto>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetListCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCompanyListItemDto>> Handle(GetListCompanyQuery request, CancellationToken cancellationToken)
        {
            Paginate<Company> companies = await _companyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                orderBy: x=>x.OrderBy(c=>c.Name),
                enableTracking: false,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCompanyListItemDto> response =
                _mapper.Map<GetListResponse<GetListCompanyListItemDto>>(companies);
            return response;
        }
    }
}