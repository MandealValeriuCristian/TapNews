using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Services.Interfaces;

public interface ICategoriesService
{
    Task<Category> GetCategoryAsync(int id);

    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> FindCategoryByNameAsync(string name);
    Task<Result<Category>> CreateCategoryAsync(Category category);
    Task<Result> UpdateCategoryAsync(Category category, CategoryDto categoryDto);
    Task<Result> DeleteCategoryAsync(Category category);
}
