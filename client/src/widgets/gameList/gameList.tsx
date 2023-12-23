import styles from "./gameList.module.scss";
import { GameCard } from "@entities/game";
import { GameListItem } from "@shared/api";
import { useTranslation } from "react-i18next";

interface Props {
    games: Array<GameListItem>;
}

export const GameList = (props: Props) => {
    const { t } = useTranslation("gameList");

    if (!props.games) {
        return <></>;
    }

    return (
        <div className={styles.root}>
            <span className={styles.header}>
                {t("results")}: {props.games.length}
            </span>
            <div className={styles.content}>
                {props.games.map((game, index) =>
                    <GameCard key={index}
                              className={styles.gameCard}
                              name={game.name}
                              posterUrl={game.posterUrl} />)}
            </div>
        </div>
    );
};