import { apiInstance } from "../base.ts";
import { CalculationFormData } from "@widgets/calculatorGameForm";
import { PlayerResultModel } from "@widgets/playersResultList";

const BASE_URL = "/api/game";

export interface GameListItem {
    id: number;
    key: string;
    name: string;
    posterUrl: string;
}

export async function getGames(): Promise<Array<GameListItem>> {
    return (await apiInstance.get(BASE_URL)).data;
}

export interface GameCalculationDetails {
    gameName: string;
}

export async function getGameCalculationDetails(id: number): Promise<GameCalculationDetails> {
    const response = await apiInstance.get(`${BASE_URL}/calculation-details/${id}`);
    return response.data;
}

export async function calculateScore(data: CalculationFormData): Promise<PlayerResultModel[]> {
    const response = await apiInstance.post(`${BASE_URL}/calculate-score`, data);
    return response.data;
}