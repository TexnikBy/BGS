import { PropsWithChildren } from "react";
import classNames from "classnames";

interface Props extends PropsWithChildren {
    type?: "submit" | "reset" | "button";
    className?: string;
    onClick?: () => void;
}

export const Button = (props: Props) => {
    return (
        <button className={classNames("button", props.className)}
                type={props.type}
                onClick={props.onClick}>
            <span className="h3 button__content">
                {props.children}
            </span>
        </button>
    );
};