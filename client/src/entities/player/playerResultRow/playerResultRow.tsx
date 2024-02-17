import styles from "./playerResultRow.module.scss";
import { LabeledValue } from "@shared/ui";

interface Props {
    place: number;
    playerNumber: number;
    playerName: string;
    totalScore: number;
}

export const PlayerResultRow = (props: Props) => {
    const getRootStyle = () => {
        if (props.place === 1) {
            return styles.firstPlace;
        }

        if (props.place === 2) {
            return styles.secondPlace;
        }

        if (props.place === 3) {
            return styles.thirdPlace;
        }

        return styles.root;
    }

    return (
        <div className={getRootStyle()}>
            <span className={styles.place}>{props.place}</span>
            <LabeledValue label={`Player ${props.playerNumber}`} value={props.playerName} />
            <span className={styles.totalScore}>{props.totalScore} pts</span>
        </div>
    );
};