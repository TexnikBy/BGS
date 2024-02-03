import styles from "./calculatorNumberFormField.module.scss";
import { NumberFormField } from "@shared/ui/formFields/numberFormField.tsx";
import { forwardRef } from "react";
import { LabeledValue } from "@shared/ui";
import { BaseCalculatorFormFieldProps } from "../../model/baseCalculatorFormField.tsx";

interface Props extends BaseCalculatorFormFieldProps {
    playerNumber: number;
    playerName: string;
}

export const CalculatorNumberFormField = forwardRef<HTMLInputElement, Props>((props, ref) =>
    <div className={styles.root}>
        <LabeledValue label={`Player ${props.playerNumber}`} value={props.playerName}/>
        <NumberFormField name={props.name}
                         onBlur={props.onBlur}
                         onChange={props.onChange}
                         ref={ref}/>
    </div>
);