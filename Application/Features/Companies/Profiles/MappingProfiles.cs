
using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Queries.GetById;
using Application.Features.Companies.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Companies.Profiles;

public class MappingProfiles : Profile
 {
  public MappingProfiles()
  {
      CreateMap<Company,CreateCompanyCommand>().ReverseMap();
      CreateMap<Company,CreatedCompanyResponse>().ReverseMap();
      CreateMap<Company, GetListCompanyListItemDto>().ReverseMap();
      CreateMap<Paginate<Company>, GetListResponse<GetListCompanyListItemDto>>().ReverseMap();
      CreateMap<Company, GetByIdCompanyResponse>().ReverseMap();
  }
}