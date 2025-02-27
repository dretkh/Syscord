using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Optional;

namespace Syscord.Users.Domain.Types.StorageAbstractions;

public interface IUsersStorage
{
    Task<bool> IsUniqueRequisiteValueTakenAsync(string name, string value);
    Task CreateAsync(User user);
    Task<IReadOnlyCollection<User>> GetByRequisiteAsync(Requisite requisite);
    Task<Option<User>> GetAsync(Guid id);
    IAsyncEnumerable<User> GetAllAsync();
}