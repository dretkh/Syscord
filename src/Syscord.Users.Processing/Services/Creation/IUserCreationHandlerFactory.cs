using Syscord.Core;
using Syscord.Users.Domain.Types;
using Syscord.Users.Service.Services.Creation.Requests;

namespace Syscord.Users.Service.Services.Creation;

public interface IUserCreationHandlerFactory
{
    IHandler<UserCreationRequest, User> Create();
}