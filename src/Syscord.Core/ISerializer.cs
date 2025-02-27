namespace Syscord.Core;

public interface ISerializer<in TIn, out TOut>
{
    TOut Serialize(TIn input);
}