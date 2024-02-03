import styles from "./leaderboardPage.module.scss";
import { PageLayout } from "@shared/ui";
import { PlayerResultModel, PlayersResultList } from "@widgets/playersResultList";
import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";

export const LeaderboardPage = () => {
    const location = useLocation();
    const [state, setState] = useState<PlayerResultModel[]>();

    useEffect(() => {
        setState(location.state);
    }, []);

    if (!state) {
        return null;
    }

    return (
        <PageLayout className={styles.root}>
            <h2 className={styles.header}>Leaderboard</h2>
            <div className={styles.results}>
                <PlayersResultList results={state} />
            </div>
        </PageLayout>
    );
};