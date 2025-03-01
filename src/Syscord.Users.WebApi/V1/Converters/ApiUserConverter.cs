using System.Linq;
using Syscord.Core;
using Syscord.Users.Domain.Types;
using Syscord.Users.WebApi.V1.Types;

namespace Syscord.Users.WebApi.V1.Converters;

public sealed class ApiUserConverter : IConverter<User, ApiUser>
{
    public ApiUser Serialize(User data)
        => new()
        {
            Id = data.Id,
            Requisites = data.Requisites.ToDictionary()
        };

    public User Deserialize(ApiUser representation) => new(representation.Id, representation.Requisites);
}