using System.Collections.Immutable;
using Optional;
using Syscord.Users.Core;
using Syscord.Users.Domain.Types;
using Syscord.Users.Domain.Types.StorageAbstractions;
using Syscord.Users.Service.Services.Creation.Requests;

namespace Syscord.Users.Service.Services;

public sealed class UsersRequestsService(
    IUsersStorage storage,
    IHandler<UserCreationRequest, User> creationHandler) : IUsersRequestsService
{
    public async Task CreateAsync(UserCreationRequest request)
    {
        await creationHandler.HandleAsync(request);
    }

    public async Task<Option<User>> GetByLoginAsync(string login)
    {
        var x = await storage.GetByRequisiteAsync(new Requisite(RequisiteNames.Login, login));
        return User.Create(ImmutableDictionary<string, string>.Empty).Some();
    }

    public async Task<Option<User>> GetByIdAsync(Guid id) => await storage.GetAsync(id);

    public IAsyncEnumerable<User> GetAllAsync()
        => storage.GetAllAsync();
}