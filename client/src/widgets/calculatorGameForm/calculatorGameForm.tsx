import { useFieldArray, useForm } from "react-hook-form";
import { CalculationAccordion } from "@entities/calculator";
import { CalculationFormData, CalculatorGameFormConfiguration } from "@widgets/calculatorGameForm/model";
import { ReactElement } from "react";
import {
    BaseCalculatorFormFieldProps,
    CalculatorFormFieldType,
    CalculatorNumberFormField
} from "@features/calculationFormFields";
import { Button } from "@shared/ui";

interface Props<T> {
    gameId: number;
    players: string[];
    config: CalculatorGameFormConfiguration<T>;
    onFormSubmit: (data: CalculationFormData) => void;
}

const CalculatorFormFields: {
    [type in CalculatorFormFieldType]: (props: BaseCalculatorFormFieldProps) => ReactElement<BaseCalculatorFormFieldProps>
} = ({
    [CalculatorFormFieldType.Number]: (props) => <CalculatorNumberFormField {...props} />,
});

export function CalculatorGameForm<T>(props: Props<T>) {
    const { control, register, handleSubmit } = useForm<CalculationFormData>({
        values: {
            gameId: props.gameId,
            models: props.players.map((playerName: string) => ({ playerName })),
        },
    });
    const { fields } = useFieldArray<CalculationFormData>({
        control,
        name: "models",
    });

    return (
        <form onSubmit={handleSubmit(props.onFormSubmit)}>
            <CalculationAccordion items={props.config.fields.map((field) => ({
                title: field.title,
                children: fields.map((arrayField, index) => {
                    const { onChange, onBlur, name, ref } = register(`models.${index}.gameData.${field.nameOfField}`);

                    return (
                        CalculatorFormFields[field.type]({
                            playerName: arrayField.playerName,
                            playerNumber: index + 1,
                            name: name,
                            onBlur: onBlur,
                            onChange: onChange,
                            ref: ref,
                            key: arrayField.id,
                        })
                    );
                }),
            }))} />
            <Button type="submit">Calculate</Button>
        </form>
    );
}