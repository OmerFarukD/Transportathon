using Application.Features.Transportations.Commands.Create;
using AutoMapper;
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

    }
}