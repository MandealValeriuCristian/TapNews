using API.Data.Repositories.Interfaces;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Article, ArticleDto>()
            .ReverseMap();
        CreateMap<Category, CategoryDto>()
            .ReverseMap();            
    }
}
