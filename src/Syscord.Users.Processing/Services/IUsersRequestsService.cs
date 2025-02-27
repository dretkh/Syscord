using Optional;
using Syscord.Users.Domain.Types;
using Syscord.Users.Service.Services.Creation.Requests;

namespace Syscord.Users.Service.Services;

public interface IUsersRequestsService
{
    Task CreateAsync(UserCreationRequest request);
    Task<Option<User>> GetByLoginAsync(string login);
    Task<Option<User>> GetByIdAsync(Guid id);
    IAsyncEnumerable<User> GetAllAsync();
}