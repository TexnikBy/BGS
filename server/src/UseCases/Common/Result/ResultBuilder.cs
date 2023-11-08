using System.Threading.Tasks;

namespace BGS.UseCases.Common.Result;

public class ResultBuilder
{
    public static Task<Result> BuildSucceed()
    {
        return Task.FromResult(new Result
        {
            IsSucceeded = true,
        });
    }
    
    public static Task<Result> BuildFailed(string message)
    {
        return Task.FromResult(new Result
        {
            IsSucceeded = false,
            Error = message,
        });
    }
}