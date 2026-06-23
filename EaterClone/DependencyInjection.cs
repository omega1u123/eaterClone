using System.IdentityModel.Tokens.Jwt;
using EaterClone.Domain;
using EaterClone.Domain.Repository;
using EaterClone.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        services.AddScoped<JwtTokenService>();
        services.AddScoped<JwtSecurityTokenHandler>();
        services.AddScoped<UserService>();
       
    
        return services;
    }

    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services)
    {
        
        services.AddAuthorization();
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuer = false,        // ← Добавьте
                    ValidateAudience = false,
                    IssuerSigningKey =
                        new SymmetricSecurityKey("your-very-secret-key-16-bytes-qwewqe-qwewqe-wqewe"u8.ToArray())
                };
            });
        
        return services;
    }
}