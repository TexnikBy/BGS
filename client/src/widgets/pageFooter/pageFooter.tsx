import styles from "./pageFooter.module.scss";
import classNames from "classnames";
import { Trans, useTranslation } from "react-i18next";

export const PageFooter = () => {
    const { t } = useTranslation("pageFooter");

    return (
        <footer className={classNames(styles.root, styles.pageFooter)}>
            <section className="">
                <div></div>
            </section>
            <div className={styles.designedBy}>
                <Trans t={t} values={{ designer: "OTCHE_SA" }}>
                    designed by <a href="https://aleksandras-groovy-site-825d93.webflow.io/">name of designer</a>
                </Trans>
            </div>
        </footer>
    );
};