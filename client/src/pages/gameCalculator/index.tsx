import { RouteObject } from "react-router-dom";
import { GameCalculatorPage } from "./gameCalculatorPage.tsx";
import {
    TyrantsOfTheUnderdarkCalculatorConfig
} from "./configs/tyrantsOfTheUnderdarkCalculatorConfig.ts";
import { StoneAgeCalculatorConfig } from "@pages/gameCalculator/configs/stoneAgeCalculatorConfig.ts";

const getPath = (gameKey: string) => `/games/:gameId-${gameKey}/calculator`;

export const GameCalculatorRouters: RouteObject[] = [
    {
        path: getPath("stone-age"),
        element: <GameCalculatorPage config={StoneAgeCalculatorConfig} />,
    },
    {
        path: getPath("battle-for-rokugan"),
        element: <GameCalculatorPage config={TyrantsOfTheUnderdarkCalculatorConfig} />,
    },
    {
        path: getPath("tyrants-of-the-underdark"),
        element: <GameCalculatorPage config={TyrantsOfTheUnderdarkCalculatorConfig} />,
    },
];