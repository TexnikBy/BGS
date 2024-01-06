import styles from "./playerInfo.module.scss";

interface Props {
    number: number;
    name: string;
}

export const PlayerInfo = (props: Props) => {
    return (
        <div className={styles.root}>
            <label>Player {props.number}</label>
            <h3>{props.name}</h3>
        </div>
    );
};