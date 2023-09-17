using Application.Features.Companies.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Companies.Rules;

public class CompanyBusinessRules : BaseBusinessRules
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyBusinessRules(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task IsThereACompany(Guid id)
    {
        var company = await _companyRepository.GetAsync(
            predicate: x=>x.Id.Equals(id)
        );

        if (company is null)
            throw new BusinessException(CompanyMessage.CompanyNotFound);
    }
    
}