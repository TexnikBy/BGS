import styles from "./gamesPage.module.scss";
import { PageLayout } from "@shared/ui";
import { GameList } from "@/widgets/gameList/gameList.tsx";
import { useEffect, useState } from "react";
import { GameListItem, getGames } from "@shared/api";
import classNames from "classnames";
import { PlayerFilters } from "@features/playerFilters";
import { SearchField } from "@shared/ui/components/searchField.tsx";

export const GamesPage = () => {
    const [games, setGames] = useState<Array<GameListItem>>([]);

    useEffect(() => {
        (async () => {
            setGames(await getGames());
        })();
    }, []);

    return (
        <PageLayout className={classNames(styles.root)}>
            <SearchField className={styles.searchInput} />
            <PlayerFilters className={styles.playerFilters} />
            <GameList games={games} />
        </PageLayout>
    );
}