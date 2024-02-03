import styles from "./playerResultRow.module.scss";
import { LabeledValue } from "@shared/ui";

interface Props {
    index: number;
    playerNumber: number;
    playerName: string;
    totalScore: number;
}

export const PlayerResultRow = (props: Props) => {
    const getPlaceStyle = () => {
        if (props.index === 0) {
            return styles.firstPlace;
        }

        if (props.index === 1) {
            return styles.secondPlace
        }

        if (props.index === 2) {
            return styles.thirdPlace;
        }

        return styles.place;
    }

    return (
        <div className={styles.root}>
            <span className={getPlaceStyle()}>{props.index + 1}</span>
            <LabeledValue label={`Player ${props.playerNumber}`} value={props.playerName} />
            <span className={styles.totalScore}>{props.totalScore} pts</span>
        </div>
    );
};