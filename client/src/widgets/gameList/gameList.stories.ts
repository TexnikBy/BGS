import type { Meta, StoryObj } from "@storybook/react";
import { GameList } from "./gameList.tsx";

const meta: Meta<typeof GameList> = {
    title: "Example/Game List",
    component: GameList,
    parameters: {
        controls: {
            include: [],
        },
    },
    args: {
        games: [
            {
                id: 1,
                key: "storybook",
                name: "First Storybook",
                posterUrl: "./GameCardPoster.jpg",
            },
            {
                id: 2,
                key: "storybook-2",
                name: "Second Storybook",
                posterUrl: "",
            },
            {
                id: 3,
                key: "storybook-3",
                name: "Third Storybook",
                posterUrl: "",
            },
        ],
    },
};

export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
};