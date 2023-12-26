using API.DTOs;
using API.Entities;
using API.Helpers;
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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticle(int id)
    {
        var article = await _articlesService.GetArticleAsync(id);
        if(article == null)
        {
            return NotFound($"No product with ID {id} has been found");
        }
        return Ok(_mapper.Map<ArticleDto>(article));
    }

    [HttpPost]
    public async Task<IActionResult> Create(ArticleDto articleDto)
    {
        var article = _mapper.Map<Article>(articleDto);
        
        var result = await _articlesService.CreateArticleAsync(article);

        if (result.IsFailure)
            return StatusCode(StatusCodes.Status500InternalServerError, $"Could not create product: {result.Error}");
        var articleForReturn = _mapper.Map<ArticleDto>(result.Value);

        return Ok(articleForReturn);
    }
}
