namespace Syscord.Users.Storage.Postgre.Entities;

public sealed class UserRequisiteEntity
{
    public required Guid UserId { get; init; }
    public required string Name { get; init; }
    public required string Value { get; init; }
    public UserEntity? User { get; init; }
}