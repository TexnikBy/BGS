export type GameSessionCalculationModel = {
    username: string;
    data?: any;
}

export type CalculationFormData = {
    models: GameSessionCalculationModel[];
}

export { CalculatorNumberFormArrayField } from "./calculatorNumberFormArrayField.tsx";