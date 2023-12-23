import { useTranslation } from "react-i18next";
import styles from "./gameCard.module.scss";
import { Card } from "@shared/ui";
import classNames from "classnames";

interface Props {
    name: string;
    posterUrl?: string;
    className?: string;
}

export const GameCard = (props: Props) => {
    const { t } = useTranslation("gameCard");

    const getImageSrc = () => props.posterUrl
        ? props.posterUrl
        : "/noGamePhoto.jpg";

    return (
        <Card className={classNames(styles.root, props.className)}>
            <img src={getImageSrc()} alt="" />
            <div className={styles.overlay} />
            <div className={styles.content}>
                <div className={styles.countOfPlayers}>2-4 {t("players")}</div>
                <div className={styles.gameName}>{props.name}</div>
            </div>
        </Card>
    );
}