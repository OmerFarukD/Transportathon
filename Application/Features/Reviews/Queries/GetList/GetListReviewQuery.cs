using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Reviews.Queries.GetList;

public class GetListReviewQuery: IRequest<GetListResponse<GetListReviewListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public string CacheKey => $"GetListReviewQuery({PageRequest.PageIndex},{PageRequest.PageSize})";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetReviews";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListReviewQueryHandler : IRequestHandler<GetListReviewQuery,GetListResponse<GetListReviewListItemDto>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetListReviewQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        
        public async Task<GetListResponse<GetListReviewListItemDto>> Handle(GetListReviewQuery request, CancellationToken cancellationToken)
        {
            Paginate<Review> reviews = await _reviewRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: x=>x.Include(x=>x.Company)
                    .Include(x=>x.AppUser),
                cancellationToken: cancellationToken,
                enableTracking: false,
                orderBy: x=>x.OrderBy(x=>x.CreatedDate)
            );

            GetListResponse<GetListReviewListItemDto> response =
                _mapper.Map<GetListResponse<GetListReviewListItemDto>>(reviews);

            return response;
        }
    }
    
}