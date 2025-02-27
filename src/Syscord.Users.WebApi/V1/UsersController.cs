using Microsoft.AspNetCore.Mvc;
using Syscord.Core;
using Syscord.Users.Service.Services;
using Syscord.Users.Service.Services.Creation.Requests;
using Syscord.Users.WebApi.V1.Types;
using DomainUser = Syscord.Users.Domain.Types.User;

namespace Syscord.Users.WebApi.V1;

[Route("v1/users")]
public sealed class UsersController(
    IUsersRequestsService usersRequestsService,
    IConverter<DomainUser, ApiUser> userApiConverter) : Controller
{
    [Route("{id:guid}")]
    [HttpGet]
    public async Task<ApiUser> GetByIdAsync(Guid id)
    {
        var user = await usersRequestsService.GetByIdAsync(id);

        return user.Match(
            some: userApiConverter.Serialize,
            none: () => throw new IllegalProgramException());
    }
    
    [Route("login/{login}")]
    [HttpGet]
    public async Task<ApiUser> GetByIdAsync(string login)
    {
        var user = await usersRequestsService.GetByLoginAsync(login);

        return user.Match(
            some: userApiConverter.Serialize,
            none: () => throw new IllegalProgramException());
    }

    [Route("")]
    [HttpPost]
    public async Task CreateUserAsync(string login)
    {
        await usersRequestsService.CreateAsync(new UserCreationRequest(login));
    }

    [Route("")]
    [HttpGet]
    public async Task<IReadOnlyCollection<ApiUser>> GetAllAsync()
        => await usersRequestsService.GetAllAsync().Select(userApiConverter.Serialize).ToListAsync();
}