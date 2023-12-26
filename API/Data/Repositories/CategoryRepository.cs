using API.Data.Repositories.Interfaces;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class CategoryRepository: Repository<Category>, ICategoriesRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CategoryRepository(DataContext context, IMapper mapper): base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public override async Task<Category> GetAsync(int id)
    {
        return await _context.Categories
            .Include(art => art.Articles)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
    public override async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories
            .Include(art => art.Articles)
            .ToListAsync();
    }

    public async Task<Category> FindCategoryByName(string name)
    {
        return await _context.Categories
            .Include(art => art.Articles)
            .FirstOrDefaultAsync(a => a.Name == name);
    }
}
