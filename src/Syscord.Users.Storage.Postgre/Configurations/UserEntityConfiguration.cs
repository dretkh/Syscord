using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syscord.Users.Storage.Postgre.Entities;

namespace Syscord.Users.Storage.Postgre.Configurations;

public sealed class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");
        builder.Property(x => x.Id).HasColumnName("id");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Requisites).WithOne(x => x.User);
    }
}