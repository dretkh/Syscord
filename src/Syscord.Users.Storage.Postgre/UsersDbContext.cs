using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Syscord.Users.Storage.Postgre.Configurations;
using Syscord.Users.Storage.Postgre.Entities;

namespace Syscord.Users.Storage.Postgre;

public sealed class UsersDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<UserEntity> Users { get; init; }
    public DbSet<UserRequisiteEntity> UserRequisites { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = configuration.GetSection(Consts.ConnectionString).Value;
        optionsBuilder
            .UseNpgsql(connectionString)
            .UseLoggerFactory(GetLoggerFactory());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserRequisiteEntityConfiguration());
    }

    private static ILoggerFactory GetLoggerFactory()
        => LoggerFactory.Create(builder => builder.AddConsole());
}