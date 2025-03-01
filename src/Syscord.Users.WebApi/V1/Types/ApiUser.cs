using System;
using System.Collections.Generic;

namespace Syscord.Users.WebApi.V1.Types;

public sealed class ApiUser
{
    public Guid Id { get; set; }
    public required Dictionary<string, string> Requisites { get; set; }
}