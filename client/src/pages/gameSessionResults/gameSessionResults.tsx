import { useLocation } from "react-router-dom";
import { PageLayout } from "@shared/ui";
import styles from "@pages/calculators/tyrantsOfTheUnderdark/tyrantsOfTheUnderdarkCalculator.module.scss";
import { GameHeaderInfo } from "@entities/game/gameHeaderInfo/gameHeaderInfo.tsx";
import { useEffect, useState } from "react";

export const GameSessionResults = () => {
    const location = useLocation();
    const [state, setState] = useState<string[]>();

    useEffect(() => {
        setState(location.state);
    }, []);

    if (!state) {
        return null;
    }

    return (
        <PageLayout>
            <GameHeaderInfo className={styles.header} gameName="TyrantsOfTheUnderdark" />
            {state.map((item) => <div style={{ fontSize: 18, paddingBottom: 10 }}>
                {item}
            </div>)}
        </PageLayout>
    );
};