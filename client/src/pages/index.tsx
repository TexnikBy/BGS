import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { GamesPage } from "@pages/game/gamesPage.tsx";

export const Routing = () => <RouterProvider router={router}/>;

const router = createBrowserRouter([
    {
        path: "/",
        element: <GamesPage/>,
    },
]);