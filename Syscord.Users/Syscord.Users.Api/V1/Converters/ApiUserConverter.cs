using Syscord.Users.Api.V1.Types;
using Syscord.Users.Core;

namespace Syscord.Users.Api.V1.Converters;

public sealed class ApiUserConverter : IFormat<User, ApiUser>
{
    public ApiUser Serialize(User data)
        => new()
        {
            Id = data.Id,
            Requisites = data.Requisites.ToDictionary()
        };

    public User Deserialize(ApiUser representation) => new(representation.Id, representation.Requisites);
}