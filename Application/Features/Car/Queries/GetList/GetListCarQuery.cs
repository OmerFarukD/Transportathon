using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Car.Queries.GetList;

public class GetListCarQuery : IRequest<GetListResponse<GetListCarItemDto>>,ICachableRequest
{
    public PageRequest PageRequest { get; set; } = new();
    
    public string CacheKey => $"GetListCarQuery({PageRequest.PageIndex},{PageRequest.PageSize})";
    public bool ByPassCache { get; }
    public string? CacheGroupKey => "GetCars";
    public TimeSpan? SlidingExpiration { get; }
    
    
    public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery,GetListResponse<GetListCarItemDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }


        public async Task<GetListResponse<GetListCarItemDto>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: x=>x.Include(c=>c.Company),
                orderBy: x=>x.OrderBy(c=>c.Id),
                enableTracking: false,
                cancellationToken: cancellationToken
            );
            var response = _mapper.Map<GetListResponse<GetListCarItemDto>>(cars);
            return response;
        }
    }
}