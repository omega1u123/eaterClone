using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EaterClone.Domain.EntityConfig;

public class DishEntityConfig : IEntityTypeConfiguration<DishEntity>
{
    public void Configure(EntityTypeBuilder<DishEntity> builder)
    {
        builder.ToTable(nameof(DishEntity));
        builder.HasKey(x => x.Id);
        
        builder.HasMany(x => x.Products).WithMany(x => x.Dishes);
    }
}