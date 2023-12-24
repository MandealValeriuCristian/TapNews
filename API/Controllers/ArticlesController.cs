using API.DTOs;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Controllers;

public class ArticlesController: BaseApiController
{
    private readonly IArticlesService _articlesService;
    private readonly IMapper _mapper;

    public ArticlesController(IArticlesService articlesService, IMapper mapper)
    {
        _articlesService = articlesService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllArticles()
    {
        var articles = await _articlesService.GetAllArticlesAsync();

        if(!articles.Any())
        {
            return NoContent();
        }
        return Ok(_mapper.Map<IEnumerable<ArticleDto>>(articles));
    }
}
