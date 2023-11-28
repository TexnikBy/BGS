namespace BGS.SharedKernel.Results;

public record Result<T> : Result
{
    public T Data { get; init; }

    private Result(bool isSucceeded)
        : base(isSucceeded) { }

    private Result(T data, bool isSucceeded)
        : base(isSucceeded)
    {
        Data = data;
    }

    public static Result<T> Success(T data) => new(data, true);

    public new static Result<T> Error(params string[] errorMessages) => new (false) { Errors = errorMessages };
}