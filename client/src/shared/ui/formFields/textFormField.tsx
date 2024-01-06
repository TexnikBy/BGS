import { InputFormField, InputFormFieldProps } from "@shared/ui/formFields/inputFormField.tsx";
import { forwardRef } from "react";

export const TextFormField = forwardRef<HTMLInputElement, InputFormFieldProps>((props, ref) =>
    <InputFormField className={props.className}
                    name={props.name}
                    onBlur={props.onBlur}
                    onChange={props.onChange}
                    placeholder={props.placeholder}
                    ref={ref}
                    type="text" />
);