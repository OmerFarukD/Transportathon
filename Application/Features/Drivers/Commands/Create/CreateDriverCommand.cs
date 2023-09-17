using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Drivers.Commands.Create;

public class CreateDriverCommand :IRequest<CreatedDriverResponse> ,ITransactionalRequest,ICacheRemoverRequest,ILoggableRequest
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public Guid CompanyId { get; set; }


    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetDrivers";
    
    public class CreateDriverCommandHandler :IRequestHandler<CreateDriverCommand,CreatedDriverResponse>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public CreateDriverCommandHandler(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }


        public async Task<CreatedDriverResponse> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            Driver driver = _mapper.Map<Driver>(request);
            Driver createdDriver = await _driverRepository.AddAsync(driver);

            CreatedDriverResponse driverResponse = _mapper.Map<CreatedDriverResponse>(createdDriver);
            return driverResponse;
        }
    }
    
}