using Application.Features.Reviews.Commands;
using Application.Features.Reviews.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Reviews.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Review, CreateReviewCommand>()
            .ForPath(x => x.CreateReviewDto.Comment,
                opt => opt.MapFrom(x => x.Comment))
            .ForPath(x => x.CreateReviewDto.Point,
                opt => opt.MapFrom(x => x.Point))
            .ForPath(X => X.CreateReviewDto.CompanyId,
                opt => opt.MapFrom(x => x.CompanyId)
            ).ReverseMap();

        CreateMap<Review, CreatedReviewResponse>().ReverseMap();

        CreateMap<Review, GetListReviewListItemDto>().ReverseMap();
        CreateMap<Paginate<Review>, GetListResponse<GetListReviewListItemDto>>().ReverseMap();

    }
}