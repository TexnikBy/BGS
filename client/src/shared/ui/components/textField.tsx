import classNames from "classnames";

interface InputFieldProps {
    type: string;
    className?: string;
    placeholder?: string;
}

export const InputField = (props: InputFieldProps) => {
    return (
        <input type={props.type}
               className={classNames("input", props.className)}
               placeholder={props.placeholder} />
    );
};