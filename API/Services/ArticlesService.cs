using API.Data;
using API.Entities;
using API.Helpers;
using API.Services.Interfaces;

namespace API.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticlesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Article>> CreateArticleAsync(Article article)
        {
            _unitOfWork.Articles.Add(article);

            var articleCreationResult = await _unitOfWork.CompleteAsync();
            
            return articleCreationResult.IsFailure
                ? Result<Article>.Fail(articleCreationResult.Error)
                : Result<Article>.Ok(await _unitOfWork.Articles.GetAsync(article.Id));
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync()
        {
            return await _unitOfWork.Articles.GetAllAsync();
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            return await _unitOfWork.Articles.GetAsync(id);
        }
    }
}
