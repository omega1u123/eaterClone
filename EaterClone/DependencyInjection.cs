using EaterClone.Domain.Repository;
using EaterClone.Services;

namespace EaterClone;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ProductRepository>();
        services.AddScoped<MealRepository>();
        services.AddScoped<DishRepository>();
        services.AddScoped<RationRepository>();
        services.AddScoped<UserRepository>();
        
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<DishService>();
        services.AddScoped<MealService>();
        services.AddScoped<RationService>();
        
        return services;
    }
}