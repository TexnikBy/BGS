import { CalculatorFormFieldType, CalculatorGameFormConfiguration } from "@widgets/calculatorGameForm/model";

interface BattleForRokuganScoringModel {
    countOfProvincialFlowers: number;
    countOfFaceUpControlTokens: number;
    secretObjectivePoints: number;
    countOfControlledTerritories: number;
}

export const StoneAgeCalculatorConfig: CalculatorGameFormConfiguration<BattleForRokuganScoringModel> = {
    fields: [
        {
            title: "countOfProvincialFlowers",
            nameOfField: "countOfProvincialFlowers",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "countOfFaceUpControlTokens",
            nameOfField: "countOfFaceUpControlTokens",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "secretObjectivePoints",
            nameOfField: "secretObjectivePoints",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "countOfControlledTerritories",
            nameOfField: "countOfControlledTerritories",
            type: CalculatorFormFieldType.Number,
        },
    ]
}