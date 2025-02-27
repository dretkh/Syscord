using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Syscord.Users.Storage.Postgre.Implementations;
using Syscord.Users.Storage.Postgre.Implementations.Converters;

namespace Syscord.Users.Storage.Postgre.DI;

public sealed class PostgreStorageAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.Register(
                context =>
                {
                    var config = context.Resolve<IConfiguration>();
                    var options = new DbContextOptionsBuilder<UsersDbContext>();
                    var connectionString = config.GetSection(Consts.ConnectionString).Value;
                    options.UseNpgsql(connectionString);
                    return new UsersDbContext(options.Options);
                })
            .AsSelf()
            .InstancePerLifetimeScope();

        builder.RegisterType<UsersStorage>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<UserEntityConverter>().AsImplementedInterfaces().SingleInstance();
    }
}