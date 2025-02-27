using Syscord.Core;
using Syscord.Users.Domain.Types;
using Syscord.Users.Domain.Types.StorageAbstractions;
using Syscord.Users.Service.Services.Creation.Requests;

namespace Syscord.Users.Service.Services.Creation.Handlers;

public sealed class UserCreationHandler(IUsersStorage usersStorage) : IHandler<PreparedRequisites, User>
{
    public async Task<User> HandleAsync(PreparedRequisites request)
    {
        var user = User.Create(request.Requisites);

        await usersStorage.CreateAsync(user);

        return user;
    }
}