namespace BGS.SharedKernel.Results;

public class ResultBuilder
{
    public static Result BuildSucceed()
    {
        return new Result
        {
            IsSucceeded = true,
        };
    }
}