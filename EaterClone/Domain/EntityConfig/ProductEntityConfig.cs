using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EaterClone.Domain.EntityConfig;

public class ProductEntityConfig : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable(nameof(ProductEntity));
        builder.HasKey(x => x.Id);
        
    }
}