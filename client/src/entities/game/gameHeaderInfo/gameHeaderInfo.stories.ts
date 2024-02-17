import type { Meta, StoryObj } from "@storybook/react";
import { GameHeaderInfo } from "./gameHeaderInfo.tsx";

const meta: Meta<typeof GameHeaderInfo> = {
    title: "Example/Game Header Info",
    component: GameHeaderInfo,
    parameters: {
        controls: {
            include: ["gameName"],
        },
    },
    args: {
        gameName: "Ticket to ride legacy"
    },
};

export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
};