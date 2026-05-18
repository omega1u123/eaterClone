using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EaterClone.Domain.EntityConfig;

public class MealEntityConfig : IEntityTypeConfiguration<MealEntity>
{
    public void Configure(EntityTypeBuilder<MealEntity> builder)
    {
        builder.ToTable(nameof(MealEntity));
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Ration).WithOne().HasForeignKey<MealEntity>(x => x.RationId);
        builder.HasMany(x => x.Dishes).WithOne().HasForeignKey(x => x.Id);
    }
}