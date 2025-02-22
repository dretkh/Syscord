using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Syscord.Users.Api.V1.Types;
using Syscord.Users.Core;
using DomainUser = Syscord.Users.User;

namespace Syscord.Users.Api.V1;

[Route("v1/users")]
public sealed class UsersController(IFormat<User, ApiUser> userApiFormat) : Controller
{
    private static readonly Dictionary<Guid, User> users = new();
    
    private readonly IFormat<User, ApiUser> userApiFormat = userApiFormat;

    [Route("{id:guid}")]
    [HttpGet]
    public Task<ApiUser> GetByIdAsync(Guid id)
    {
        if (users.TryGetValue(id, out var user))
        {
            return Task.FromResult(userApiFormat.Serialize(user));
        }

        throw new IllegalProgramException();
    }

    [HttpPost]
    public Task CreateUserAsync()
    {
        var user = DomainUser.Create(ImmutableDictionary<string, string>.Empty);
        users.Add(user.Id, user);
        return Task.CompletedTask;
    }
}