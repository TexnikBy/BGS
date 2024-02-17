import type { Meta, StoryObj } from "@storybook/react";
import { CalculatorGameForm } from "./calculatorGameForm.tsx";
import { CalculatorFormFieldType } from "@widgets/calculatorGameForm/model";

const meta: Meta<typeof CalculatorGameForm> = {
    title: "Example/Calculator Game Form",
    component: CalculatorGameForm,
    parameters: {
        controls: {
            include: ["players"],
        },
    },
    args: {
        gameId: 1,
        players: ["First Storybook", "Second Storybook"],
        config: {
            fields: [
                {
                    title: "Number field",
                    type: CalculatorFormFieldType.Number,
                    nameOfField: "object1" as never,
                },
                {
                    title: "Just for test",
                    type: CalculatorFormFieldType.Number,
                    nameOfField: "object2" as never,
                },
            ],
        },
    },
};

export default meta;
type Story = StoryObj<typeof meta>;

export const Default: Story = {
};