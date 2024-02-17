import type { Meta, StoryObj } from "@storybook/react";
import { GameCard } from "./gameCard.tsx";

const meta: Meta<typeof GameCard> = {
    title: "Example/Game Gard",
    component: GameCard,
    parameters: {
        controls: {
            include: ["name"],
        },
    },
    args: {
        name: "Ticket to ride legacy",
    },
};

export default meta;
type Story = StoryObj<typeof meta>;

export const WithPoster: Story = {
    args: {
        posterUrl: "/GameCardPoster.jpg",
    },
};

export const WithoutPoster: Story = {
};