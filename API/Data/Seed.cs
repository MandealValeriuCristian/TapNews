using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Data;

public class Seed
{
    public static async Task SeedArticles(DataContext context)
    {
        if (await context.Articles.AnyAsync()) return;

        var categoriesData = await File.ReadAllTextAsync("Data/CategoriesSeedData.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        
        var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData, options);

        foreach (var category in categories)
        {
            context.Categories.Add(category);
        }
        await context.SaveChangesAsync();
    }
}
