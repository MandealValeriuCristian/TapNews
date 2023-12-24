using API.Data.Repositories.Interfaces;
using API.DTOs;
using API.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class ArticleRepository: Repository<Article>, IArticlesRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ArticleRepository(DataContext context, IMapper mapper): base(context)
    {
        _context = context;
        _mapper = mapper;
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
