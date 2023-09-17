using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Messages.Queries.GetList;

public class GetListMessageQuery : IRequest<GetListResponse<GetListMessageListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public string CacheKey => $"GetListMessageQuery({PageRequest.PageIndex},{PageRequest.PageSize})";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetMessages";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListMessageQueryHandler : IRequestHandler<GetListMessageQuery,GetListResponse<GetListMessageListItemDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetListMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMessageListItemDto>> Handle(GetListMessageQuery request, CancellationToken cancellationToken)
        {
            Paginate<Message> messages = await _messageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: x=>
                    x.Include(m=>m.Company)
                    .Include(m=>m.AppUser),
                cancellationToken: cancellationToken,
                enableTracking: false,
                orderBy: x=>x.OrderBy(x=>x.CreatedDate)
            );

            GetListResponse<GetListMessageListItemDto> response =
                _mapper.Map<GetListResponse<GetListMessageListItemDto>>(messages);

            return response;
        }
    }
}