using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyCommand : IRequest<CreatedCompanyResponse>,ICacheRemoverRequest,ITransactionalRequest,ILoggableRequest
{
    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetCompanies";
    
    
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand,CreatedCompanyResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        

        public async Task<CreatedCompanyResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(request);
            company.Id = new Guid();

            Company createdCompany = await _companyRepository.AddAsync(company);

            CreatedCompanyResponse response = _mapper.Map<CreatedCompanyResponse>(createdCompany);
            
            return response;


        }
    }
    
}