import type { Meta, StoryObj } from "@storybook/react";

import { LabeledValue } from "./labeledValue.tsx";

const meta: Meta<typeof LabeledValue> = {
    title: "Example/Labeled Value",
    component: LabeledValue,
};

export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
    args: {
        label: "Player 1",
        value: "Storybook",
    }
};