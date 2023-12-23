import logo from "/logo.svg";
import classNames from "classnames";
import styles from "./pageHeader.module.scss"
import { useTranslation } from "react-i18next";

export const PageHeader = () => {
    const { t } = useTranslation("pageHeader");

    return (
        <header className={classNames(styles.root)}>
            <div className={styles.content}>
                <img src={logo} alt="bgs-logo"/>
                <div className={styles.signUp}>{t("signUp")}</div>
            </div>
        </header>
    );
};