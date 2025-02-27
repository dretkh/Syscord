namespace Syscord.Core;

public interface IHandler<in TRequest, TResponse>
{
    Task<TResponse> HandleAsync(TRequest request);
}