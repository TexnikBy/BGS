import { PropsWithChildren } from "react";
import classNames from "classnames";

interface Props extends PropsWithChildren {
    className?: string;
    onClick?: () => void;
}

export const Card = (props: Props) => {
    return (
        <div className={classNames("card", props.className)}
             onClick={props.onClick}>
            {props.children}
        </div>
    );
};