import styles from "./playersResultList.module.scss";
import { PlayerResultRow } from "@entities/player";

interface Props {
    results: PlayerResultModel[];
}

export interface PlayerResultModel {
    place: number;
    playerNumber: number;
    playerName: string;
    totalScore: number;
}

export const PlayersResultList = ({ results }: Props) => (
    <div className={styles.root}>
        {results.map((item, index) => (
            <PlayerResultRow key={index}
                             place={item.place}
                             playerNumber={item.playerNumber}
                             playerName={item.playerName}
                             totalScore={item.totalScore} />
        ))}
    </div>
);