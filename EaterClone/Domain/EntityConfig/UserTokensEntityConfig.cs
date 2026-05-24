using EaterClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EaterClone.Domain.EntityConfig;

public class UserTokensEntityConfig : IEntityTypeConfiguration<UserTokensEntity>
{
    public void Configure(EntityTypeBuilder<UserTokensEntity> builder)
    {
        builder.ToTable(nameof(UserTokensEntity));
        builder.HasKey(x => x.Id);
    }
}