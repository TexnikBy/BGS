import styles from "./gamesPage.module.scss";
import { PageLayout } from "@shared/ui";
import { GameList } from "@widgets/gameList/gameList.tsx";
import { useEffect, useState } from "react";
import { GameListItem, getGames } from "@shared/api";
import classNames from "classnames";
import { PlayerFilters } from "@features/playerFilters";
import { useNavigate } from "react-router-dom";
import { SearchFormField } from "@shared/ui/formFields/searchFormField.tsx";

export const GamesPage = () => {
    const navigate = useNavigate();
    const [games, setGames] = useState<Array<GameListItem>>([]);

    useEffect(() => {
        (async () => {
            setGames(await getGames());
        })();
    }, []);

    const handleGameCardClick = (game: GameListItem) =>
        navigate(`${game.id}-${game.key}/calculator`, { state: game });

    return (
        <PageLayout className={classNames(styles.root)}>
            <SearchFormField className={styles.searchInput} />
            <PlayerFilters className={styles.playerFilters} />
            <GameList games={games} onGameCardClick={handleGameCardClick} />
        </PageLayout>
    );
};