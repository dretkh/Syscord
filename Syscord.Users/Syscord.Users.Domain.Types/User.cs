using System;
using System.Collections.Generic;

namespace Syscord.Users.Domain.Types;

public sealed class User : UserBase
{
    public User(Guid id, IReadOnlyDictionary<string, string> requisites) : base(requisites)
    {
        Id = id;
    }

    public Guid Id { get; }

    public static User Create(IReadOnlyDictionary<string, string> requisites)
    {
        return new User(Guid.NewGuid(), requisites);
    }
}