using System;
using System.Collections.Generic;

namespace Syscord.Users;

public sealed class User : UserBase
{
    public static User Create(IReadOnlyDictionary<string, string> requisites)
        => new User(Guid.NewGuid(), requisites);
    
    public User(Guid id, IReadOnlyDictionary<string, string> requisites) : base(requisites)
    {
        Id = id;
    }

    public Guid Id { get; }
}