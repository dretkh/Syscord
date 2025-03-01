using Autofac;
using Syscord.Users.Storage.Postgre.Implementations;
using Syscord.Users.Storage.Postgre.Implementations.Converters;

namespace Syscord.Users.Storage.Postgre.DI;

public sealed class PostgreStorageAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterType<UsersDbContext>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<UsersStorage>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<UserEntityConverter>().AsImplementedInterfaces().SingleInstance();
    }
}