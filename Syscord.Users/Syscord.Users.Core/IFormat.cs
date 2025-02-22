namespace Syscord.Users.Core;

public interface IFormat<TData, TRepresentation>
{
    TRepresentation Serialize(TData data);
    TData Deserialize(TRepresentation representation);
}