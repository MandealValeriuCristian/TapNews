using API.Entities;

namespace API.Services.Interfaces;

public interface IArticlesService
{
    Task<Article> GetArticleAsync(int id);
    Task<IEnumerable<Article>> GetAllArticlesAsync();
}
