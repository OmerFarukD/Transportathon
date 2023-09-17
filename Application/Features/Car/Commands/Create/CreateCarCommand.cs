using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Enums;
using MediatR;
using Domain.Entities;
namespace Application.Features.Car.Commands.Create;

public class CreateCarCommand : IRequest<CreatedCarResponse>,ITransactionalRequest,ICacheRemoverRequest,ILoggableRequest
{
    public CarType CarType { get; set; }
    public string CarDetail { get; set; }
    public string Plate { get; set; }
    public Guid CompanyId { get; set; }

    
    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetCars";
    
    
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand,CreatedCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Domain.Entities.Car>(request);
            
            var createdCar = await _carRepository.AddAsync(car);
            
            var response = _mapper.Map<CreatedCarResponse>(createdCar);

            return response;
        }
    }

}