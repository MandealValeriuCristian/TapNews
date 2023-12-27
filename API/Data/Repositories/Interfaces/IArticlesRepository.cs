using API.Entities;
using API.Helpers;

namespace API.Data.Repositories.Interfaces;

public interface IArticlesRepository: IRepository<Article>
{
    Task<PagedList<Article>> GetAllWithParams(ArticleParams articleParams);
}

