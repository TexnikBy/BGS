import styles from "./playerInput.module.scss";
import { Button, InputFormFieldProps, TextFormField } from "@shared/ui";
import { forwardRef } from "react";

interface Props extends InputFormFieldProps {
    playerNumber: number;
    onDeleteClick: (playerNumber: number) => void;
}

export const PlayerInput = forwardRef<HTMLInputElement, Props>((props, ref) => {
    return (
        <div className={styles.root}>
            <div className={styles.content}>
                <span className={styles.playerNumber}>
                    {`Player ${props.playerNumber}`}
                </span>
                <Button type="button"
                        className="button button-link"
                        onClick={() => props.onDeleteClick(props.playerNumber)}>
                    Delete
                </Button>
            </div>
            <TextFormField className={props.className}
                           name={props.name}
                           onBlur={props.onBlur}
                           onChange={props.onChange}
                           placeholder="name"
                           ref={ref} />
        </div>
    );
});