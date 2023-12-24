using API.Data.Repositories.Interfaces;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class ArticleRepository: Repository<Article>, IArticlesRepository
{
    private readonly DataContext _context;
    public ArticleRepository(DataContext context): base(context)
    {
        _context = context;
    }

    public override async Task<Article> GetAsync(int id)
    {
        return await _context.Articles
            .Include(cat => cat.Category)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public override async Task<IEnumerable<Article>> GetAllAsync()
    {
        return await _context.Articles
            .Include(cat => cat.Category)
            .ToListAsync();
    }
}
