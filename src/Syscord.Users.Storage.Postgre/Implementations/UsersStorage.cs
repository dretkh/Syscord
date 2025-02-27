using Microsoft.EntityFrameworkCore;
using Optional;
using Optional.Collections;
using Syscord.Users.Core;
using Syscord.Users.Domain.Types;
using Syscord.Users.Domain.Types.StorageAbstractions;
using Syscord.Users.Storage.Postgre.Entities;

namespace Syscord.Users.Storage.Postgre.Implementations;

public sealed class UsersStorage(UsersDbContext dbContext, IConverter<User, UserEntity> userConverter) : IUsersStorage
{
    public async Task<bool> IsUniqueRequisiteValueTakenAsync(string name, string value)
        => await dbContext.UserRequisites
            .AnyAsync(x => x.Name == name && x.Value == value);

    public async Task CreateAsync(User user)
    {
        dbContext.Add(userConverter.Serialize(user));
        await dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<IReadOnlyCollection<User>> GetByRequisiteAsync(Requisite requisite)
        => await dbContext.UserRequisites
            .Where(x => x.Name == requisite.Name && x.Value == requisite.Value)
            .Include(x => x.User)
            .AsNoTracking()
            .AsAsyncEnumerable()
            .Select(Convert)
            .ToListAsync();

    private User Convert(UserRequisiteEntity entity)
        => entity.User is null
            ? throw new IllegalProgramException()
            : userConverter.Deserialize(entity.User);

    public async Task<Option<User>> GetAsync(Guid id)
    {
        var result = await dbContext.Users
            .Where(x => x.Id == id)
            .Include(x => x.Requisites)
            .AsNoTracking()
            .AsAsyncEnumerable()
            .Select(userConverter.Deserialize)
            .ToListAsync();

        return result.FirstOrNone();
    }

    public IAsyncEnumerable<User> GetAllAsync()
        => dbContext.Users
            .Include(x => x.Requisites)
            .AsNoTracking()
            .AsAsyncEnumerable()
            .Select(userConverter.Deserialize);
}