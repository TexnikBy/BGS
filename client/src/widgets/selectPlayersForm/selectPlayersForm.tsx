import { useFieldArray, useForm } from "react-hook-form";
import styles from "./selectPlayersForm.module.scss";
import classNames from "classnames";
import { PlayerInput } from "@entities/player";
import { Button } from "@shared/ui";

type FormData = {
    players: Array<{ name: string }>;
}

interface Props {
    onSubmit: (players: string[]) => void;
}

export const SelectPlayersForm = (props: Props) => {
    const { control, register, handleSubmit } = useForm<FormData>({ values: { players: [{ name: "" }] } });
    const { fields, append, remove } = useFieldArray({
        control,
        name: "players",
    });

    const onSubmit = handleSubmit((data) => props.onSubmit(data.players.map((player) => player.name)));

    return (
        <form className={styles.root} onSubmit={onSubmit}>
            {fields.map((field, index) => {
                const { onChange, onBlur, name, ref } = register(`players.${index}.name` as const);
                return <PlayerInput key={field.id}
                                    className={styles.playerInput}
                                    name={name}
                                    onBlur={onBlur}
                                    onChange={onChange}
                                    ref={ref}
                                    playerNumber={index + 1}
                                    onDeleteClick={(playerNumber) => remove(playerNumber - 1)} />
            })}
            <Button type="button"
                    className={classNames("button-link", styles.addPlayerButton)}
                    onClick={() => append({ name: "" })}>
                +Add player
            </Button>
            <Button type="submit"
                    className={styles.submitButton}>
                Start
            </Button>
        </form>
    );
};