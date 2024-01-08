import { FieldArrayWithId, Path, UseFormRegister } from "react-hook-form";
import { CalculatorNumberFormField } from "@features/calculationFormFields";
import { CalculationFormData } from "./index.ts";

interface Props<T> {
    fields: FieldArrayWithId<CalculationFormData, "models">[];
    register: UseFormRegister<CalculationFormData>;
    nameOfField: Path<T>;
}

export function CalculatorNumberFormArrayField<T>({ fields, register, nameOfField }: Props<T>) {
    return fields.map((field, index) => {
        const { onChange, onBlur, name, ref } = register(`models.${index}.data.${nameOfField}` as const);

        return (
            <CalculatorNumberFormField key={field.id}
                                       index={index}
                                       username={field.username}
                                       name={name}
                                       onBlur={onBlur}
                                       onChange={onChange}
                                       ref={ref} />
        );
    });
};