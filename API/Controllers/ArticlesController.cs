using API.DTOs;
using API.Entities;
using API.Extensions;
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
    public async Task<ActionResult<PagedList<Article>>> GetAllArticles([FromQuery]ArticleParams articleParams)
    {
        var articles = await _articlesService.GetAllArticlesWithParams(articleParams);

        if(!articles.Any())
        {
            return NoContent();
        }
        Response.AddPaginationHeader(articles.MetaData);
        return Ok(_mapper.Map<IEnumerable<ArticleDto>>(articles));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticle(int id)
    {
        var article = await _articlesService.GetArticleAsync(id);
        if(article == null)
        {
            return NotFound($"No article with ID {id} has not been found");
        }
        return Ok(_mapper.Map<ArticleDto>(article));
    }

    [HttpPost]
    public async Task<IActionResult> Create(ArticleDto articleDto)
    {
        var article = _mapper.Map<Article>(articleDto);
        
        var result = await _articlesService.CreateArticleAsync(article);

        if (result.IsFailure)
            return BadRequest($"Could not create article: {result.Error}");
        var articleForReturn = _mapper.Map<ArticleDto>(result.Value);

        return Ok(articleForReturn);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ArticleDto articleDto)
    {
        var articleFromRepo = await _articlesService.GetArticleAsync(id);
        if (articleFromRepo == null)
            return NotFound($"Cannot find article with id {id}");

        var result = await _articlesService.UpdateArticleAsync(articleFromRepo, articleDto);
        if (result.IsFailure)
            return BadRequest($"Could not update article: {result.Error}");
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var article = await _articlesService.GetArticleAsync(id);
        if (article == null)
            return NotFound("That article does not exist.");

        var result = await _articlesService.DeleteArticleAsync(article);
        if (result.IsFailure)
            return BadRequest($"An error occurred while trying to delete the article from database: {result.Error}");
        
        return NoContent();
    }
}
