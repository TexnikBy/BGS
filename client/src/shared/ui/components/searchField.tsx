import classNames from "classnames";
import { InputField } from "@shared/ui/components/textField.tsx";
import { useTranslation } from "react-i18next";

interface Props {
    className?: string;
}

export const SearchField = (props: Props) => {
    const { t } = useTranslation("components");

    return (<div className={classNames("search-input", props.className)}>
        <InputField type="search" placeholder={t("search")}/>
    </div>);
};