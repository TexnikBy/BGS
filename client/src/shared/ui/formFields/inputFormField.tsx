import classNames from "classnames";
import { forwardRef } from "react";
import { ChangeHandler } from "react-hook-form";

export interface InputFormFieldProps {
    className?: string;
    name?: string;
    onBlur?: ChangeHandler;
    onChange?: ChangeHandler;
    placeholder?: string;
}

interface Props extends InputFormFieldProps {
    type: string;
}

export const InputFormField = forwardRef<HTMLInputElement, Props>((props, ref) =>
    <input className={classNames("input", props.className)}
           name={props.name}
           onBlur={props.onBlur}
           onChange={props.onChange}
           placeholder={props.placeholder}
           ref={ref}
           type={props.type} />
);