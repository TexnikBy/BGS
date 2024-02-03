import { GameSessionCalculationModel } from "./gameSessionCalculationModel.ts";

export type CalculationFormData = {
    gameId: number;
    models: GameSessionCalculationModel[];
}