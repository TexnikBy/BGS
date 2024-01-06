import { PropsWithChildren } from "react";
import classNames from "classnames";

interface Props extends PropsWithChildren {
    type: "submit" | "reset" | "button";
    className?: string;
}

export const Button = ({ type, className, children }: Props) => {
    return (
        <button className={classNames("button", className)} type={type}>
            <span className="h3 button__content">
                {children}
            </span>
        </button>
    );
};