namespace BGS.Api.Controllers.Constants;

internal static class Routes
{
    public const string Api = "/api";
    
    public static class Game
    {
        public const string CalculateScore = "calculate-score";
        public const string Create = "create";
        public const string AllGames = "list";
        public const string GameById = "{gameId}";
    }
}