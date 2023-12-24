using API.Entities;
using API.Helpers;

namespace API.Services.Interfaces;

public interface IArticlesService
{
    Task<Article> GetArticleAsync(int id);
    Task<IEnumerable<Article>> GetAllArticlesAsync();
    Task<Result<Article>> CreateArticleAsync(Article article);
}
