using System;
using System.Collections.Generic;

namespace Syscord.Users.Storage.Postgre.Entities;

public sealed class UserEntity
{
    public required Guid Id { get; init; }
    public required List<UserRequisiteEntity> Requisites { get; init; } = [];
}