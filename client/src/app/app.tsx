import { PageHeader } from "@widgets/pageHeader/pageHeader.tsx";
import { PageFooter } from "@widgets/pageFooter/pageFooter.tsx";
import { Routing } from "@/pages";
import "./app.scss";

function App() {
    return (
        <div className="app">
            <PageHeader />
            <Routing />
            <PageFooter />
        </div>
    );
}

export default App;
