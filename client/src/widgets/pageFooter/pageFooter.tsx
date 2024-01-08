import styles from "./pageFooter.module.scss";
import classNames from "classnames";

export const PageFooter = () => {
    return (
        <footer className={classNames(styles.root, styles.pageFooter)}>
            <section className="">
                <div></div>
            </section>
            <div className={styles.designedBy}>
                designed by <a href="https://aleksandras-groovy-site-825d93.webflow.io/">OTCHE_SA</a>
            </div>
        </footer>
    );
};