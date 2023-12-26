using API.Data;
using API.Entities;
using API.Helpers;
using API.Services.Interfaces;

namespace API.Services;

public class CategoriesService : ICategoriesService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Category> FindCategoryByNameAsync(string categoryName)
    {
        return await _unitOfWork.Categories.FindCategoryByName(categoryName);
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        return await _unitOfWork.Categories.GetAsync(id);
    }
}
