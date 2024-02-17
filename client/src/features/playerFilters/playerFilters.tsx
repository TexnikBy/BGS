import { ToggleGroup, ToggleGroupItem } from "@radix-ui/react-toggle-group";
import styles from "./playerFilters.module.scss";
import classNames from "classnames";
import { useState } from "react";

interface Props {
    className?: string;
}

export const PlayerFilters = (props: Props) => {
    const [value, setValue] = useState("all");

    const valueChangeHandler = (newValue: string) => {
        if (newValue) {
            setValue(newValue);
        }
    }

    return (
        <ToggleGroup className={classNames(styles.root, props.className)}
                     type="single"
                     value={value}
                     onValueChange={valueChangeHandler}>
            <ToggleGroupItem value="all">
                All
            </ToggleGroupItem>
            <ToggleGroupItem value="two">
                2 players
            </ToggleGroupItem>
            <ToggleGroupItem value="twoToFour">
                2-4 players
            </ToggleGroupItem>
            <ToggleGroupItem value="fiveOrMore">
                5+ players
            </ToggleGroupItem>
        </ToggleGroup>
    );
};