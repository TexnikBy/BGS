import type { Meta, StoryObj } from "@storybook/react";

import { PlayerFilters } from "./playerFilters.tsx";

const meta: Meta<typeof PlayerFilters> = {
    title: "Example/Player Filters",
    component: PlayerFilters,
    parameters: {
        controls: {
            //include: [],
        },
    },
    args: {}
};

export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
};