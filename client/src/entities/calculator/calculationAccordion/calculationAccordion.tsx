import * as Accordion from "@radix-ui/react-accordion";
import styles from "./calculationAccordion.module.scss";
import { ReactNode } from "react";
import playingDice from "/playingDice.svg";

type ControlType = {
    title: string;
    children: ReactNode;
}

interface Props {
    items: ControlType[];
}

export const CalculationAccordion = ({ items }: Props) => {
    return (
        <div className={styles.root}>
            <Accordion.Root className={styles.root} defaultValue={items[0].title} type="single" collapsible>
                {items.map((item, index) => (
                    <Accordion.Item key={index} className={styles.accordionItem} value={item.title}>
                        <AccordionTrigger title={item.title} />
                        <Accordion.Content className={styles.accordionContent}>
                            {item.children}
                        </Accordion.Content>
                    </Accordion.Item>
                ))}
            </Accordion.Root>
        </div>
    );
};

interface AccordionTriggerProps {
    title: string;
}

const AccordionTrigger = (props: AccordionTriggerProps) => (
    <Accordion.Header className={styles.accordionHeader}>
        <Accordion.Trigger className={styles.accordionTrigger}>
            <img src={playingDice} alt="bgs-plaining-dice" />
            <h2 className={styles.accordionTriggerContent}>
                {props.title}
            </h2>
        </Accordion.Trigger>
    </Accordion.Header>
);