using API.Data;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticlesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Article>> CreateArticleAsync(Article article)
        {
            _unitOfWork.Articles.Add(article);

            var articleCreationResult = await _unitOfWork.CompleteAsync();
            
            return articleCreationResult.IsFailure
                ? Result<Article>.Fail(articleCreationResult.Error)
                : Result<Article>.Ok(await _unitOfWork.Articles.GetAsync(article.Id));
        }

        public async Task<Result> DeleteArticleAsync(Article article)
        {
            _unitOfWork.Articles.Remove(article);

            var articleDeleteResult = await _unitOfWork.CompleteAsync();
            return articleDeleteResult.Success 
                ? Result.Ok()
                : Result.Fail(articleDeleteResult.Error);
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync()
        {
            return await _unitOfWork.Articles.GetAllAsync();
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            return await _unitOfWork.Articles.GetAsync(id);
        }

        public async Task<Result> UpdateArticleAsync(Article article, ArticleDto articleDto)
        {
           _mapper.Map(articleDto, article);

            var articleResult = await _unitOfWork.CompleteAsync();
            return articleResult.IsFailure
                ? Result.Fail(articleResult.Error)
                : Result.Ok();
        }
    }
}
