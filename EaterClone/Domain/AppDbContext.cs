using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EaterClone.Domain;

public class AppDbContext : DbContext
{
    public DbSet<ProductEntity> ProductEntities { get; set; }
    public DbSet<DishEntity> DishEntities { get; set; }
    public DbSet<MealEntity> MealEntities { get; set; }
    public DbSet<RationEntity> RationEntities { get; set; }
    public DbSet<UserEntity> UserEntities { get; set; }
    public DbSet<JwtTokensEntity> JwtTokensEntities { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        const string connectionString = "Host=localhost;Port=5432;Database=eater-clone-db;Username=postgres;Password=postgres";

        options.UseNpgsql(connectionString);
    }
}