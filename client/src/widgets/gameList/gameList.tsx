import styles from "./gameList.module.scss";
import { GameCard } from "@entities/game";
import { GameListItem } from "@shared/api";

interface Props {
    games: Array<GameListItem>;
    onGameCardClick?: (game: GameListItem) => void;
}

export const GameList = (props: Props) => {
    if (!props.games) {
        return <></>;
    }

    return (
        <div className={styles.root}>
            <span className={styles.header}>
                results: {props.games.length}
            </span>
            <div className={styles.content}>
                {props.games.map((game, index) => (
                    <GameCard key={index}
                              className={styles.gameCard}
                              name={game.name}
                              posterUrl={game.posterUrl}
                              onClick={() => props.onGameCardClick?.(game)} />
                ))}
            </div>
        </div>
    );
};