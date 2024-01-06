import { PropsWithChildren } from "react";
import classNames from "classnames";

interface Props extends PropsWithChildren {
    className?: string;
}

export const PageLayout = (props: Props) => {
    return (
        <div className={classNames("page-layout", props.className)}>
            {props.children}
        </div>
    );
};