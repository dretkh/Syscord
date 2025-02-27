using Microsoft.EntityFrameworkCore;
using Syscord.Users.Storage.Postgre.Configurations;
using Syscord.Users.Storage.Postgre.Entities;

namespace Syscord.Users.Storage.Postgre;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserRequisiteEntity> UserRequisites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserRequisiteEntityConfiguration());
    }
}