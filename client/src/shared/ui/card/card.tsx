import { PropsWithChildren } from "react";
import classNames from "classnames";

interface Props extends PropsWithChildren {
    className?: string;
}

export const Card = (props: Props) => {
    return (
        <div className={classNames("card", props.className)}>
            {props.children}
        </div>
    );
}