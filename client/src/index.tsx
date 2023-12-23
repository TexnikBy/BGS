import React from "react"
import ReactDOM from "react-dom/client"
import App from "./app/app.tsx"

import "./i18n.ts";

ReactDOM.createRoot(document.getElementById("root")!).render(
    <React.StrictMode>
        <App />
    </React.StrictMode>,
);