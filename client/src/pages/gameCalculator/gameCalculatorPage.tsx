import styles from "./gameCalculatorPage.module.scss";
import { PageLayout } from "@shared/ui";
import { useEffect, useState } from "react";
import { GameHeaderInfo } from "@entities/game/gameHeaderInfo/gameHeaderInfo.tsx";
import { SelectPlayersForm } from "@widgets/selectPlayersForm/selectPlayersForm.tsx";
import { CalculationFormData, CalculatorGameForm, CalculatorGameFormConfiguration } from "@widgets/calculatorGameForm";
import { calculateScore, getGameCalculationDetails } from "@shared/api";
import { useNavigate, useParams } from "react-router-dom";

type State = {
    gameName: string;
    currentStep: number;
    players: Array<string>;
}

interface Props<T> {
    config: CalculatorGameFormConfiguration<T>;
}

export function GameCalculatorPage<T>({ config }: Props<T>) {
    const navigate = useNavigate();
    const { gameId } = useParams();
    const [state, setState] = useState<State>({
        currentStep: 1,
        players: [],
        gameName: "",
    });

    useEffect(() => {
        const fetchData = async () => {
            const data = await getGameCalculationDetails(Number(gameId));
            setState(prev => ({
                ...prev,
                gameName: data.gameName,
            }));
        }

        fetchData();
    }, []);

    if (!state.gameName) {
        return null;
    }

    const selectedPlayersHandler = (players: Array<string>) => {
        setState(prev => ({ ...prev, currentStep: 2, players: players }));
    }

    const calculateHandler = async (data: CalculationFormData) => {
        const results = await calculateScore(data);
        navigate("/results", { state: results });
    }

    return (
        <PageLayout className={styles.root}>
            <GameHeaderInfo className={styles.header} gameName={state.gameName} />
            {state.currentStep === 1 && (
                <SelectPlayersForm onSubmit={selectedPlayersHandler} />
            )}
            {state.currentStep === 2 && (
                <CalculatorGameForm gameId={Number(gameId)}
                                    players={state.players}
                                    onFormSubmit={calculateHandler}
                                    config={config}
                />
            )}
        </PageLayout>
    );
};