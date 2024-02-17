import type { Meta, StoryObj } from "@storybook/react";

import { PlayersResultList } from "./playersResultList.tsx";

const meta: Meta<typeof PlayersResultList> = {
    title: "Example/Players Result List",
    component: PlayersResultList,
    parameters: {
        controls: {
            include: [],
        },
    },
    args: {
        results: [
            {
                place: 1,
                playerNumber: 1,
                playerName: "First Storybook",
                totalScore: 1000,
            },
            {
                place: 2,
                playerNumber: 2,
                playerName: "Second Storybook",
                totalScore: 100,
            },
            {
                place: 3,
                playerNumber: 3,
                playerName: "Third Storybook",
                totalScore: 10,
            },
            {
                place: 4,
                playerNumber: 4,
                playerName: "Fourth Storybook",
                totalScore: 1,
            },
            {
                place: 5,
                playerNumber: 5,
                playerName: "Fifth Storybook",
                totalScore: 0,
            },
        ]
    },
};

export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
};