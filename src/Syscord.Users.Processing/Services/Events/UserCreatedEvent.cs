namespace Syscord.Users.Service.Services.Events;

public sealed class UserCreatedEvent
{
    public required Guid Id { get; set; }
    public required IReadOnlyDictionary<string, string> Requisites { get; set; }
}