import { ToggleGroup, ToggleGroupItem } from "@radix-ui/react-toggle-group";
import styles from "./playerFilters.module.scss";
import classNames from "classnames";
import { useTranslation } from "react-i18next";

interface Props {
    className?: string;
}

export const PlayerFilters = (props: Props) => {
    const { t } = useTranslation("playerFilters");

    return (
        <ToggleGroup className={classNames(styles.root, props.className)}
                     type="single"
                     defaultValue="all">
            <ToggleGroupItem value="all">
                All
            </ToggleGroupItem>
            <ToggleGroupItem value="two">
                2 {t("players")}
            </ToggleGroupItem>
            <ToggleGroupItem value="twoToFour">
                2-4 {t("players")}
            </ToggleGroupItem>
            <ToggleGroupItem value="fiveOrMore">
                5+ {t("players")}
            </ToggleGroupItem>
        </ToggleGroup>
    );
};