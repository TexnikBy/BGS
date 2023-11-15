namespace BGS.SharedKernel.Results;

public record Result
{
    public bool IsSucceeded { get; private init; }

    protected Result(bool isSucceeded)
    {
        IsSucceeded = isSucceeded;
    }

    public static Result Success() => new(true);

    public static Result Fail(string error) => new(true);
}