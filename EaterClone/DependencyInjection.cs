using System.Text;
using EaterClone.Domain;
using EaterClone.Domain.Repository;
using EaterClone.Services;
using Microsoft.IdentityModel.Tokens;

namespace EaterClone;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();
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
        services.AddScoped<UserService>();
    
        return services;
    }

    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services)
    {
        services.AddScoped<JwtTokenService>();
        services.AddAuthorization();
        services.AddAuthentication()
            .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey("secret-key"u8.ToArray())
                });
        
        return services;
    }
}