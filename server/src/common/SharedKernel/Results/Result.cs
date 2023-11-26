namespace BGS.SharedKernel.Results;

public record Result
{
    public bool IsSucceeded { get; private init; }

    public IEnumerable<string> Errors { get; init; } = new List<string>();

    protected Result(bool isSucceeded)
    {
        IsSucceeded = isSucceeded;
    }

    protected Result(bool isSucceeded, IEnumerable<string> errors)
    {
        IsSucceeded = isSucceeded;
        Errors = errors;
    }

    public static Result Success() => new(true);

    public static Result Error(params string[] errorMessages) => new (false, errorMessages);
}