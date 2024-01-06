import { PropsWithChildren, useEffect } from "react";
import classNames from "classnames";
import { useLocation } from "react-router-dom";

interface Props extends PropsWithChildren {
    className?: string;
}

export const PageLayout = (props: Props) => {
    const { pathname } = useLocation();

    useEffect(() => window.scrollTo(0, 0), [pathname]);

    return (
        <div className={classNames("page-layout", props.className)}>
            {props.children}
        </div>
    );
};