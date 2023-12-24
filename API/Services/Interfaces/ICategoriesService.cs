using API.Entities;
using API.Helpers;

namespace API.Services.Interfaces;

public interface ICategoriesService
{
    Task<Category> GetCategoryAsync(int id);

    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByNameAsync(string name);

}
