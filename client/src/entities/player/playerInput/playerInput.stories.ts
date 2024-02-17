import type { Meta, StoryObj } from "@storybook/react";
import { PlayerInput } from "./playerInput.tsx";

const meta: Meta<typeof PlayerInput> = {
    title: "Example/Player Name Input",
    component: PlayerInput,
    parameters: {
        controls: {
            include: ["playerNumber", "placeholder"],
        },
    },
    args: {
        playerNumber: 1,
        placeholder: "Name",
    },
};

export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
};