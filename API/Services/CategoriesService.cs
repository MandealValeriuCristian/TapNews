using API.Data;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services;

public class CategoriesService : ICategoriesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _unitOfWork.Categories.GetAllAsync();
    }

    public async Task<Category> FindCategoryByNameAsync(string categoryName)
    {
        return await _unitOfWork.Categories.FindCategoryByName(categoryName);
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        return await _unitOfWork.Categories.GetAsync(id);
    }

    public async Task<Result<Category>> CreateCategoryAsync(Category category)
    {
        _unitOfWork.Categories.Add(category);
        var categoryCreationResult = await _unitOfWork.CompleteAsync();

        return categoryCreationResult.IsFailure
            ? Result<Category>.Fail(categoryCreationResult.Error)
            : Result<Category>.Ok(await _unitOfWork.Categories.GetAsync(category.Id));
    }

    public async Task<Result> UpdateCategoryAsync(Category category, CategoryDto categoryDto)
    {
        _mapper.Map(categoryDto, category);
        var categoryResult = await _unitOfWork.CompleteAsync();

        return categoryResult.IsFailure
            ? Result.Fail(categoryResult.Error)
            : Result.Ok();
    }

    public async Task<Result> DeleteCategoryAsync(Category category)
    {
        _unitOfWork.Categories.Remove(category);

        var categoryDeleteResult = await _unitOfWork.CompleteAsync();
        return categoryDeleteResult.Success
            ? Result.Ok()
            : Result.Fail(categoryDeleteResult.Error);
    }
}
