interface Props {
    label: string;
    value: string;
}

export const LabeledValue = ({ label, value }: Props) => {
    return (
        <div className="labeled-value">
            <span className="labeled-value__label">{label}</span>
            <span className="labeled-value__value">{value}</span>
        </div>
    );
}