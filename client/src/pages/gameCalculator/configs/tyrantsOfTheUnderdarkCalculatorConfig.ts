import { CalculatorFormFieldType, CalculatorGameFormConfiguration } from "@widgets/calculatorGameForm/model";

interface TyrantsOfTheUnderdarkScoringModel {
    controlSitesScore: number;
    totalControlSitesScore : number;
    troopsTrophyHallScore: number;
    deckValueScore: number;
    innerCircleDeckValueScore: number;
    victoryPointTokensScore: number;
}

export const TyrantsOfTheUnderdarkCalculatorConfig: CalculatorGameFormConfiguration<TyrantsOfTheUnderdarkScoringModel> = {
    fields: [
        {
            title: "controlSitesScore",
            nameOfField: "controlSitesScore",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "totalControlSitesScore",
            nameOfField: "totalControlSitesScore",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "troopsTrophyHallScore",
            nameOfField: "troopsTrophyHallScore",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "deckValueScore",
            nameOfField: "deckValueScore",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "innerCircleDeckValueScore",
            nameOfField: "innerCircleDeckValueScore",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "victoryPointTokensScore",
            nameOfField: "victoryPointTokensScore",
            type: CalculatorFormFieldType.Number,
        },
    ]
}