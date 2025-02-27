using Autofac;
using Syscord.Users.Service.Services;
using Syscord.Users.Service.Services.Creation;
using Syscord.Users.Service.Services.Creation.Handlers;
using Syscord.Users.Storage.Postgre.DI;

namespace Syscord.Users.Service.DI;

public sealed class UsersProcessingAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterModule(new PostgreStorageAutofacModule());

        builder.RegisterType<UserRequisitesPreparationHandler>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<UserCreationHandler>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<UserCreationHandlerFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.Register(context => context.Resolve<IUserCreationHandlerFactory>().Create())
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        builder.RegisterType<UsersRequestsService>().AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}