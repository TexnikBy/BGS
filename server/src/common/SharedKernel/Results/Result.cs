namespace BGS.SharedKernel.Results;

public record Result
{
    public bool IsSucceeded { get; private init; }

    public IEnumerable<string> Errors { get; init; } = new List<string>();

    protected Result(bool isSucceeded)
    {
        IsSucceeded = isSucceeded;
    }

    public static Result Success() => new(true);
}