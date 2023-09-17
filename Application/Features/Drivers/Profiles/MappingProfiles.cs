using Application.Features.Drivers.Commands.Create;
using Application.Features.Drivers.Queries.GetById;
using Application.Features.Drivers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Drivers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Driver, CreateDriverCommand>().ReverseMap();
        CreateMap<Driver, CreatedDriverResponse>().ReverseMap();

        CreateMap<Driver, GetListDriverListItemDto>().ReverseMap();
        CreateMap<Paginate<Driver>,GetListResponse<GetListDriverListItemDto>>().ReverseMap();

        CreateMap<Driver, GetByIdDriverResponse>().ReverseMap();

    }
}