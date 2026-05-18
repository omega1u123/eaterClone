using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EaterClone.Domain.EntityConfig;

public class RationEntityConfig : IEntityTypeConfiguration<RationEntity>
{
    public void Configure(EntityTypeBuilder<RationEntity> builder)
    {
        builder.ToTable(nameof(RationEntity));
        builder.HasKey(x => x.Id);
             
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        builder.HasMany(x => x.Meals).WithOne().HasForeignKey(x => x.Id);
    }
}