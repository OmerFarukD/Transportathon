using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Messages.Commands.Create;

public class CreateMessageCommand : IRequest<CreatedMessageResponse>, ITransactionalRequest,ICacheRemoverRequest,ILoggableRequest
{
    public int AppUserId { get; set; }
    public MessageCreateDto MessageCreateDto { get; set; } = new();


    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetMessages";
    
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand,CreatedMessageResponse>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public CreateMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<CreatedMessageResponse> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            Message message = _mapper.Map<Message>(request);

            Message createdMessage = await _messageRepository.AddAsync(message);

            CreatedMessageResponse response = _mapper.Map<CreatedMessageResponse>(createdMessage);

            return response;

        }
    }
    
}