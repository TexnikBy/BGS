import { InputFormFieldProps } from "@shared/ui";
import { InputFormField } from "@shared/ui/formFields/inputFormField.tsx";
import classNames from "classnames";

export const SearchFormField = (props: InputFormFieldProps) => (
    <InputFormField className={classNames("search-input", props.className)} type="search" placeholder={"search"} />
);