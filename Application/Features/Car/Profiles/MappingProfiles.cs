using Application.Features.Car.Commands.Create;
using Application.Features.Car.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;

namespace Application.Features.Car.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Car, CreateCarCommand>().ReverseMap();
        CreateMap<Domain.Entities.Car, CreatedCarResponse>().ReverseMap();
        CreateMap<Paginate<Domain.Entities.Car>, GetListResponse<GetListCarItemDto>>().ReverseMap();
        CreateMap<Domain.Entities.Car, GetListCarItemDto>().ReverseMap().ReverseMap();
    }
}