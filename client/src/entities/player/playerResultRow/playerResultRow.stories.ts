import type { Meta, StoryObj } from "@storybook/react";
import { PlayerResultRow } from "./playerResultRow.tsx";

const meta: Meta<typeof PlayerResultRow> = {
    title: "Example/Player Result Row",
    component: PlayerResultRow,
    args: {
        playerNumber: 1,
        playerName: "Storybook",
        totalScore: 123,
    },
};

export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
    args: {
        place: 4,
    },
};

export const FirstPlace: Story = {
    args: {
        place: 1,
    },
};

export const SecondPlace: Story = {
    args: {
        place: 2,
    },
};

export const ThirdPlace: Story = {
    args: {
        place: 3,
    },
};