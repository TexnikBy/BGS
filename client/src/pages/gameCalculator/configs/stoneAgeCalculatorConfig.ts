import { CalculatorFormFieldType, CalculatorGameFormConfiguration } from "@widgets/calculatorGameForm/model";

interface StoneAgeScoringModel {
    currentPoint: number;
    countOfResources: number;
    numberOfFoodProduction: number;
    numberOfFarmers: number;
    numberOfTools: number;
    numberOfToolMakers: number;
    numberOfBuildings: number;
    numberOfHutBuilders: number;
    numberOfShamans: number;
    numberOfPeople: number;
    collectionOfGreenCivilizationCards: number[];
}

export const StoneAgeCalculatorConfig: CalculatorGameFormConfiguration<StoneAgeScoringModel> = {
    fields: [
        {
            title: "currentPoint",
            nameOfField: "currentPoint",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "countOfResources",
            nameOfField: "countOfResources",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "numberOfFoodProduction",
            nameOfField: "numberOfFoodProduction",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "numberOfFarmers",
            nameOfField: "numberOfFarmers",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "numberOfTools",
            nameOfField: "numberOfTools",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "numberOfToolMakers",
            nameOfField: "numberOfToolMakers",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "numberOfBuildings",
            nameOfField: "numberOfBuildings",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "numberOfHutBuilders",
            nameOfField: "numberOfHutBuilders",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "numberOfShamans",
            nameOfField: "numberOfShamans",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "numberOfPeople",
            nameOfField: "numberOfPeople",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "1 collectionOfGreenCivilizationCards",
            nameOfField: "collectionOfGreenCivilizationCards.0",
            type: CalculatorFormFieldType.Number,
        },
        {
            title: "2 collectionOfGreenCivilizationCards",
            nameOfField: "collectionOfGreenCivilizationCards.1",
            type: CalculatorFormFieldType.Number,
        },
    ]
}