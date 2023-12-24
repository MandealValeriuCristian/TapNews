using API.Data.Repositories.Interfaces;
using API.Helpers;

namespace API.Data;

public interface IUnitOfWork : IDisposable
{
    IArticlesRepository Articles { get; }

    ICategoriesRepository Categories { get; }

    Task<Result> CompleteAsync();
}

