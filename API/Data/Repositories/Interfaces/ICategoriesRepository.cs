using API.Entities;

namespace API.Data.Repositories.Interfaces;

public interface ICategoriesRepository: IRepository<Category>
{
    Task<Category> GetCategoryByName(string name);
}
