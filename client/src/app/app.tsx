import "./app.scss";
import { PageHeader } from "@widgets/pageHeader/pageHeader.tsx";
import { PageFooter } from "@widgets/pageFooter/pageFooter.tsx";
import { Routing } from "@/pages";
import { Suspense } from "react";

function App() {
    return (
        <Suspense>
            <div className="app">
                <PageHeader />
                <Routing />
                <PageFooter />
            </div>
        </Suspense>
    );
}

export default App;
