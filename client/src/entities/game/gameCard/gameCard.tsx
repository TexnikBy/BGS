import styles from "./gameCard.module.scss";
import { Card } from "@shared/ui";
import classNames from "classnames";

interface Props {
    name: string;
    posterUrl?: string;
    className?: string;
    onClick?: () => void;
}

export const GameCard = (props: Props) => {
    const getImageSrc = () => props.posterUrl
        ? props.posterUrl
        : "/noGamePhoto.jpg";

    return (
        <Card className={classNames(styles.root, props.className)}
              onClick={props.onClick}>
            <img src={getImageSrc()} alt="" />
            <div className={styles.overlay} />
            <div className={styles.content}>
                <h5>2-4 players</h5>
                <div className={styles.gameName}>{props.name}</div>
            </div>
        </Card>
    );
}