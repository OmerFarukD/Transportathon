using Application.Features.Transportations.Commands.Create;
using Application.Features.Transportations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Transportations.Profiles;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Transportation, CreateTransportationCommand>()
            .ForPath(x => x.TransportationDto.ReservationStatus,
                opt => opt.MapFrom(x => x.ReservationStatus))
            .ForPath(x => x.TransportationDto.TransportDate,
                opt => opt.MapFrom(x => x.TransportDate))
            .ForPath(x => x.TransportationDto.TransportType,
                opt => opt.MapFrom(x => x.TransportType))
            .ReverseMap();

        CreateMap<Transportation, CreatedTransportationResponse>().ReverseMap();
        CreateMap<Transportation, GetListTransportationListItemDto>().ReverseMap();
        CreateMap<Paginate<Transportation>, GetListResponse<GetListTransportationListItemDto>>().ReverseMap();

    }
}