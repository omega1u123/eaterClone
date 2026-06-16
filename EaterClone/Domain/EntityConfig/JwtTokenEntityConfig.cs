using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EaterClone.Domain.EntityConfig;

public class JwtTokenEntityConfig : IEntityTypeConfiguration<JwtTokensEntity>
{
    public void Configure(EntityTypeBuilder<JwtTokensEntity> builder)
    {
        builder.ToTable(nameof(JwtTokensEntity));
        builder.HasKey(x => x.Id);
    }
}