using System.Collections.Generic;

namespace Syscord.Users.Domain.Types;

public abstract class UserBase(IReadOnlyDictionary<string, string> requisites)
{
    public IReadOnlyDictionary<string, string> Requisites { get; } = requisites;
}