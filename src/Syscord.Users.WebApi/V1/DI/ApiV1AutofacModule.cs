using Autofac;
using Syscord.Users.Service.DI;
using Syscord.Users.WebApi.V1.Converters;

namespace Syscord.Users.WebApi.V1.DI;

public sealed class ApiV1AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterModule(new UsersProcessingAutofacModule());
        builder.RegisterType<ApiUserConverter>().AsImplementedInterfaces().AsSelf();
    }
}