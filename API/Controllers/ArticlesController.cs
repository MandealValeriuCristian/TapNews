using API.DTOs;
using API.Entities;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Controllers;

public class ArticlesController: BaseApiController
{
    private readonly IArticlesService _articlesService;
    private readonly IMapper _mapper;
    private readonly ICategoriesService _categoriesService;

    public ArticlesController(IArticlesService articlesService, IMapper mapper, ICategoriesService categoriesService)
    {
        _articlesService = articlesService;
        _mapper = mapper;
        _categoriesService = categoriesService;
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
        //var category = _categoriesService.GetCategoryAsync(articleDto.Category.Id);
        //if (articleDto.Category != null)
        //var category = _categoriesService.GetCategoryByNameAsync(articleDto.Category);
        var article = _mapper.Map<Article>(articleDto);

        var result = await _articlesService.CreateArticleAsync(article);

        if (result.IsFailure)
            return StatusCode(StatusCodes.Status500InternalServerError, $"Could not create product: {result.Error}");
        var articleForReturn = _mapper.Map<ArticleDto>(result.Value);

        return Ok(articleForReturn);
    }
}
