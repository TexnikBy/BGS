import { InputFormFieldProps } from "@shared/ui";
import { RefCallBack } from "react-hook-form";

export interface BaseCalculatorFormFieldProps extends InputFormFieldProps {
    playerNumber: number;
    playerName: string;
    ref: RefCallBack;
    key: string;
}