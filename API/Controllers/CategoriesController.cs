using API.DTOs;
using API.Entities;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoriesController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(IMapper mapper, ICategoriesService categoriesService)
    {
        _mapper = mapper;
        _categoriesService = categoriesService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoriesService.GetAllCategoriesAsync();
        if (!categories.Any())
        {
            return NoContent();
        }
        return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var category = await _categoriesService.GetCategoryAsync(id);
        if (category == null)
        {
            return NotFound($"No category with ID {id} has not been found");
        }
        return Ok(_mapper.Map<CategoryDto>(category));
    }
    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        
        var result = await _categoriesService.CreateCategoryAsync(category);

        if (result.IsFailure)
        {
            return BadRequest($"Could not create category: {result.Error}");
        }
        var categoryForReturn = _mapper.Map<CategoryDto>(result.Value);

        return Ok(categoryForReturn);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id,  CategoryDto categoryDto)
    {
        var categoryFromRepo = await _categoriesService.GetCategoryAsync(id);
        if (categoryFromRepo == null)
            return NotFound($"Cannot find category with id {id}");
        var result = await _categoriesService.UpdateCategoryAsync(categoryFromRepo, categoryDto);
        if (result.IsFailure)
            return BadRequest($"Could not update category: {result.Error}");
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _categoriesService.GetCategoryAsync(id);
        if (category == null) return NotFound("That category does not exist.");

        var result = await _categoriesService.DeleteCategoryAsync(category);
        if (result.IsFailure)
            return BadRequest($"An error occurred while trying to delete the category from database: {result.Error}");
        return NoContent();
    }
}
