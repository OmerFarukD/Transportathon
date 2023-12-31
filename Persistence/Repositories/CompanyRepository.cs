﻿using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyRepository : EfRepositoryBase<Company,Guid,BaseDbContext>,ICompanyRepository
{
    public CompanyRepository(BaseDbContext context) : base(context)
    {
    }
}