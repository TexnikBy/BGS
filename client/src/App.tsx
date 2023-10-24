import React, { useEffect, useState } from "react";

function App() {
    const [data, setData] = useState("waiting...");

    useEffect(() => {
        fetch('/api/test')
            .then((response) => response.text())
            .then((result) => {
                setData(result);
            });
    }, []);

    return (
        <div>
            <header>
                <p>
                    <code>{data}</code>
                </p>
            </header>
        </div>
    );
}

export default App;
