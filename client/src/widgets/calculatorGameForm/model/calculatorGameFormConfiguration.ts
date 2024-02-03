import { Path } from "react-hook-form";

export enum CalculatorFormFieldType {
    Number = 1,
}

export interface CalculatorConfigurationField<T> {
    title: string;
    nameOfField: Path<T>;
    type: CalculatorFormFieldType;
}


export interface CalculatorGameFormConfiguration<T> {
    fields: Array<CalculatorConfigurationField<T>>,
}