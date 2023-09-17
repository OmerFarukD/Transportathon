using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Queries.GetById;

public class GetByIdCompanyQuery : IRequest<GetByIdCompanyResponse>
{
    public Guid Id { get; set; }
    
    
    public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQuery,GetByIdCompanyResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly CompanyBusinessRules _companyBusinessRules;

        public GetByIdCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper, CompanyBusinessRules companyBusinessRules)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _companyBusinessRules = companyBusinessRules;
        }
        public async Task<GetByIdCompanyResponse> Handle(GetByIdCompanyQuery request, CancellationToken cancellationToken)
        {
            await _companyBusinessRules.IsThereACompany(request.Id);
            
            Company company = await _companyRepository.GetAsync(
                predicate: x=>x.Id==request.Id ,
                enableTracking: false,
                cancellationToken: cancellationToken,
                withDeleted: false
            );

            GetByIdCompanyResponse response = _mapper.Map<GetByIdCompanyResponse>(company);
            return response;


        }
    }
}