using Application.Features.Messages.Commands.Create;
using Application.Features.Messages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Messages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Message, CreateMessageCommand>()
            .ForPath(x=>x.MessageCreateDto.CompanyId,
                opt=>opt.MapFrom(x=>x.CompanyId))
            .ForPath(X=>X.MessageCreateDto.MessageContent,
                opt=>opt.MapFrom(x=>x.MessageContent)
                )
            .ReverseMap();
        CreateMap<Message, CreatedMessageResponse>().ReverseMap();

        CreateMap<Message, GetListMessageListItemDto>()
            // .ForMember(x=>x.AppUserEmail,
            //     opt=>opt.MapFrom(x=>x.AppUser.Email)
            //     )
            .ReverseMap();
        CreateMap<Paginate<Message>, GetListResponse<GetListMessageListItemDto>>().ReverseMap();
    }
}