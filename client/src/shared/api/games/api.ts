import { apiInstance } from "../base.ts";

const BASE_URL = "/api/game";

export interface GameListItem {
    id: string;
    name: string;
    posterUrl: string;
}

export async function getGames(): Promise<Array<GameListItem>> {
    return (await apiInstance.get(BASE_URL)).data;
}