import logo from "/logo.svg";
import classNames from "classnames";
import styles from "./pageHeader.module.scss"

export const PageHeader = () => {
    return (
        <header className={classNames(styles.root)}>
            <div className={styles.content}>
                <img src={logo} alt="bgs-logo"/>
                <div className={styles.signUp}>signUp</div>
            </div>
        </header>
    );
};