import styles from "./calculatorNumberFormField.module.scss";
import { PlayerInfo } from "@entities/player/playerInfo/playerInfo.tsx";
import { NumberFormField } from "@shared/ui/formFields/numberFormField.tsx";
import { forwardRef } from "react";
import { InputFormFieldProps } from "@shared/ui";

interface Props extends InputFormFieldProps {
    index: number;
    username: string;
}

export const CalculatorNumberFormField = forwardRef<HTMLInputElement, Props>((props, ref) =>
    <div className={styles.root}>
        <PlayerInfo number={props.index + 1} name={props.username}/>
        <NumberFormField name={props.name}
                         onBlur={props.onBlur}
                         onChange={props.onChange}
                         ref={ref}/>
    </div>
);