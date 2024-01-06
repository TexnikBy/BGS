import styles from "./gameHeaderInfo.module.scss";
import classNames from "classnames";

interface Props {
    gameName: string;
    className?: string;
}

export const GameHeaderInfo = (props: Props) => {
    return (
        <div className={classNames(styles.root, props.className)}>
            <h2 className={styles.gameName}>{props.gameName}</h2>
            <span>
                2-6 players for this game
            </span>
        </div>
    );
}