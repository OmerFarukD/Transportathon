using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reviews.Commands;

public class CreateReviewCommand : IRequest<CreatedReviewResponse>, ILoggableRequest,ITransactionalRequest,ICacheRemoverRequest
{
    public int AppUserId { get; set; }
    public CreateReviewDto CreateReviewDto { get; set; } = new();

    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetReviews";
    
    
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand,CreatedReviewResponse>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<CreatedReviewResponse> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            Review review = _mapper.Map<Review>(request);
            review.Id = new Guid();
            Review createdReview = await _reviewRepository.AddAsync(review);

            CreatedReviewResponse response = _mapper.Map<CreatedReviewResponse>(createdReview);
            return response;

        }
    }
    
}