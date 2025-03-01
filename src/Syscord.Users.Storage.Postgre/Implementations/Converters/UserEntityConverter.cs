using System.Linq;
using Syscord.Core;
using Syscord.Users.Domain.Types;
using Syscord.Users.Storage.Postgre.Entities;

namespace Syscord.Users.Storage.Postgre.Implementations.Converters;

public sealed class UserEntityConverter : IConverter<User, UserEntity>
{
    public UserEntity Serialize(User data)
    {
        return new UserEntity
        {
            Id = data.Id,
            Requisites = data.Requisites
                .Select(x => new UserRequisiteEntity
                {
                    UserId = data.Id,
                    Name = x.Key,
                    Value = x.Value
                })
                .ToList()
        };
    }

    public User Deserialize(UserEntity representation)
    {
        return new User(representation.Id, representation.Requisites.ToDictionary(x => x.Name, x => x.Value));
    }
}