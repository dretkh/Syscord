namespace Syscord.Users.Core.Extensions;

public static class HandlerExtensions
{
    public static IHandler<TIn, TOut> Chain<TIn, TMiddle, TOut>(
        this IHandler<TIn, TMiddle> left,
        IHandler<TMiddle, TOut> right)
        => new ChainingHandler<TIn, TMiddle, TOut>(left, right);
}