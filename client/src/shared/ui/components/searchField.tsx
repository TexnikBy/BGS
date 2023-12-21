import classNames from "classnames";
import { InputField } from "@shared/ui/components/textField.tsx";

interface Props {
    className?: string;
}

export const SearchField = (props: Props) => {
    return (<div className={classNames("search-input", props.className)}>
        <InputField type="search" placeholder="Search"/>
    </div>);
};