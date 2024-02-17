import styles from "./gameHeaderInfo.module.scss";
import classNames from "classnames";

interface Props {
    gameName: string;
    className?: string;
}

export const GameHeaderInfo = (props: Props) => {
    return (
        <div className={classNames(styles.root, props.className)}>
            <span className={styles.gameName}>{props.gameName}</span>
            <span>
                2-6 players for this game
            </span>
        </div>
    );
}