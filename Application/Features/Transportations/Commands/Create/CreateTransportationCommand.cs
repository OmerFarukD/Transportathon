using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transportations.Commands.Create;

public class CreateTransportationCommand : IRequest<CreatedTransportationResponse>, ICacheRemoverRequest,ITransactionalRequest,ILoggableRequest
{
    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetTransportations";

    public CreateTransportationDto TransportationDto { get; set; } = new();
    public int AppUserId { get; set; }
    
    
    public class CreateTransportationCommandHandler : IRequestHandler<CreateTransportationCommand,CreatedTransportationResponse>
    {
        private readonly ITransportationRepository _transportationRepository;
        private readonly IMapper _mapper;

        public CreateTransportationCommandHandler(ITransportationRepository transportationRepository, IMapper mapper)
        {
            _transportationRepository = transportationRepository;
            _mapper = mapper;
        }
        public async Task<CreatedTransportationResponse> Handle(CreateTransportationCommand request, CancellationToken cancellationToken)
        {
            Transportation transportation = _mapper.Map<Transportation>(request);

            transportation.Id = new Guid();

            Transportation created = await _transportationRepository.AddAsync(transportation);

            CreatedTransportationResponse response = _mapper.Map<CreatedTransportationResponse>(created);

            return response;
        }
    }
}