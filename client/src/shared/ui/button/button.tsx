import { PropsWithChildren } from "react";
import classNames from "classnames";

interface Props extends PropsWithChildren {
    type?: "submit" | "reset" | "button";
    className?: string;
    onClick?: () => void;
    disabled?: boolean;
}

export const Button = (props: Props) => {
    return (
        <button className={classNames("button", props.className)}
                disabled={props.disabled}
                type={props.type}
                onClick={props.onClick}>
            <span className="h3 button__content">
                {props.children}
            </span>
        </button>
    );
};