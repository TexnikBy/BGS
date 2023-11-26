namespace BGS.SharedKernel.Results;

public record Result<T> : Result
{
    public T Data { get; init; }

    private Result(T data, bool isSucceeded)
        : base(isSucceeded)
    {
        Data = data;
    }

    private Result(bool isSucceeded, IEnumerable<string> errors)
        : base(isSucceeded, errors)
    {
    }

    public static Result<T> Success(T data) => new(data, true);

    public new static Result<T> Error(params string[] errorMessages) => new (false, errorMessages);
}