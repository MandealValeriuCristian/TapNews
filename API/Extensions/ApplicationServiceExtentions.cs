using API.Data.Repositories.Interfaces;
using API.Data.Repositories;
using API.Data;
using API.Services.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtentions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IArticlesRepository, ArticleRepository>();
        services.AddScoped<ICategoriesRepository, CategoryRepository>();

        services.AddScoped<IArticlesService, ArticlesService>();
        services.AddScoped<ICategoriesService, CategoriesService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
