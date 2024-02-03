import { createBrowserRouter, Navigate, RouterProvider } from "react-router-dom";
import { GamesPage } from "@pages/games/gamesPage.tsx";
import { LeaderboardPage } from "@pages/leaderboardPage/leaderboardPage.tsx";
import { GameCalculatorRouters } from "@pages/gameCalculator";

export const Routing = () => <RouterProvider router={router} />;

const router = createBrowserRouter([
    {
        path: "/",
        element: <Navigate to="/games" replace={true} />,
    },
    {
        path: "/games",
        element: <GamesPage />,
    },
    ...GameCalculatorRouters,
    {
        path: "/results",
        element: <LeaderboardPage />,
    }
]);