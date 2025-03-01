using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syscord.Users.Storage.Postgre.Entities;

namespace Syscord.Users.Storage.Postgre.Configurations;

public sealed class UserRequisiteEntityConfiguration : IEntityTypeConfiguration<UserRequisiteEntity>
{
    public void Configure(EntityTypeBuilder<UserRequisiteEntity> builder)
    {
        builder.ToTable("user_requisites");
        
        builder.Property(x => x.UserId).HasColumnName("userid");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Value).HasColumnName("value");
        
        builder.HasKey(
            x => new
            {
                x.UserId,
                x.Name
            });

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Requisites)
            .HasForeignKey(x => x.UserId);
    }
}