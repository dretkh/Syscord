namespace Syscord.Users.Core;

public interface IDeserializer<in TIn, out TOut>
{
    TOut Deserialize(TIn input);
}