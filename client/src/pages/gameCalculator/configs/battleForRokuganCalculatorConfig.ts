import { CalculatorFormFieldType, CalculatorGameFormConfiguration } from "@widgets/calculatorGameForm/model";

interface BattleForRokuganScoringModel {
    countOfProvincialFlowers: number;
    countOfFaceUpControlTokens: number;
    secretObjectivePoints: number;
    countOfControlledRegions: number;
    countOfControlledProvinces: number;
}

export const BattleForRokuganCalculatorConfig: CalculatorGameFormConfiguration<BattleForRokuganScoringModel> = {
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
            title: "countOfControlledRegions",
            nameOfField: "countOfControlledRegions",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "countOfControlledProvinces",
            nameOfField: "countOfControlledProvinces",
            type: CalculatorFormFieldType.Number,
        },
    ]
}