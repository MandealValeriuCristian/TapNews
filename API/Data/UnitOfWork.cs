using API.Data.Repositories.Interfaces;
using API.Helpers;

namespace API.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    public UnitOfWork(DataContext context, IArticlesRepository articles, ICategoriesRepository categories)
    {
        _context = context;
        Articles = articles;
        Categories = categories;
    }

    public IArticlesRepository Articles { get; set; }

    public ICategoriesRepository Categories { get; set; }

    public async Task<Result> CompleteAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception e)
        {
            return Result.Fail($"Error Message: {e.Message}, Inner Exception: {e.InnerException}");
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
