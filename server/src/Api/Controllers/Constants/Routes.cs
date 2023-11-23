namespace BGS.Api.Controllers.Constants;

internal static class Routes
{
    public const string Api = "/api";
    
    public static class Game
    {
        public const string CalculateScore = "calculate-score";
        public const string Details = "details/{gameId}";
    }
    
    public static class Identity
    {
        public const string Login = "login";
    }
}