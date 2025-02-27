using Syscord.Core;
using Syscord.Core.Extensions;
using Syscord.Users.Domain.Types;
using Syscord.Users.Service.Services.Creation.Requests;

namespace Syscord.Users.Service.Services.Creation;

public sealed class UserCreationHandlerFactory(
    IHandler<UserCreationRequest, PreparedRequisites> requisitesPreparationHandler,
    IHandler<PreparedRequisites, User> creationHandler) : IUserCreationHandlerFactory
{
    public IHandler<UserCreationRequest, User> Create()
        => requisitesPreparationHandler.Chain(creationHandler);
}