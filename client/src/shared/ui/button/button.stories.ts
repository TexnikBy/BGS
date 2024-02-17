import type { Meta, StoryObj } from "@storybook/react";

import { Button } from "./button.tsx";

const meta: Meta<typeof Button> = {
    title: "Example/Button",
    component: Button,
    parameters: {
        controls: {
            include: ["children", "className", "disabled"],
        },
    },
    args: {
        children: "Title",
    },
};

export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
    args: {
        disabled: false,
    }
};

export const Secondary: Story = {
    args: {
        className: "button-secondary",
        disabled: false,
    }
};

export const Disabled: Story = {
    args: {
        disabled: true,
    }
};

export const Link: Story = {
    args: {
        className: "button-link",
    }
};