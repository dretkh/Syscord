namespace Syscord.Users.Core;

public interface IConverter<TData, TRepresentation> :
    ISerializer<TData, TRepresentation>,
    IDeserializer<TRepresentation, TData>
{
}