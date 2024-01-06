import { InputFormFieldProps } from "@shared/ui";
import { InputFormField } from "@shared/ui/formFields/inputFormField.tsx";
import classNames from "classnames";
import { forwardRef } from "react";

export const NumberFormField = forwardRef<HTMLInputElement, InputFormFieldProps>((props, ref) =>
    <InputFormField className={classNames("number-input", props.className)}
                    name={props.name}
                    onBlur={props.onBlur}
                    onChange={props.onChange}
                    placeholder={props.placeholder ?? "—"}
                    ref={ref}
                    type="number" />
);