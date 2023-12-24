using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Article, ArticleDto>()
            .ForMember(dest => dest.Category,
            opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<ArticleDto, Article>()
            .ForPath(dest => dest.Category.Name,
            opt => opt.MapFrom(src => src.Category));
    }

}
