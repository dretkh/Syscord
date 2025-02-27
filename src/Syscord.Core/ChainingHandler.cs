namespace Syscord.Core;

public sealed class ChainingHandler<TIn, TMiddle, TOut>(
    IHandler<TIn, TMiddle> left,
    IHandler<TMiddle, TOut> right)
    : IHandler<TIn, TOut>
{
    public async Task<TOut> HandleAsync(TIn request)
    {
        var middle = await left.HandleAsync(request);

        return await right.HandleAsync(middle);
    }
}