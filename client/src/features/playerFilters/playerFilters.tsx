import { ToggleGroup, ToggleGroupItem } from "@radix-ui/react-toggle-group";
import styles from "./playerFilters.module.scss";
import classNames from "classnames";

interface Props {
    className?: string;
}

export const PlayerFilters = (props: Props) => {
    return (
        <ToggleGroup className={classNames(styles.root, props.className)}
                     type="single"
                     defaultValue="all">
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