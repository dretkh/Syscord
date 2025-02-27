namespace Syscord.Users.Core;

public abstract class Result<TValue, TError>
{
    public abstract TValue Value { get; }
    public abstract TError Error { get; }

    public static Result<TValue, TError> AsSuccess(TValue value)
    {
        return new Success(value);
    }

    public static Result<TValue, TError> AsFail(TError error)
    {
        return new Fail(error);
    }

    public bool IsSuccess()
    {
        return this is Success;
    }

    public bool IsFail()
    {
        return this is Fail;
    }

    public sealed class Success(TValue value) : Result<TValue, TError>
    {
        public override TValue Value { get; } = value;
        public override TError Error => throw new IllegalProgramException();
    }

    public sealed class Fail(TError error) : Result<TValue, TError>
    {
        public override TValue Value => throw new IllegalProgramException();
        public override TError Error { get; } = error;
    }
}