namespace Syscord.Core;

public interface IValidator<TInput, TError>
{
    Result<TInput, TError> Validate(TInput input);
}