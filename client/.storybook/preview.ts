import "../src/app/app.scss";
import type { Preview } from "@storybook/react";

const bgsViewports = {
    iphone5: {
        name: "iPhone 5",
        styles: {
            width: "320px",
            height: "568px",
        },
    },
    mobile: {
        name: "Mobile",
        styles: {
            width: "360px",
            height: "640px",
        },
    },
    largeMobile: {
        name: "Large mobile",
        styles: {
            width: "420px",
            height: "780px",
        },
    },
};

const preview: Preview = {
    parameters: {
        actions: { argTypesRegex: "^on[A-Z].*" },
        controls: {
            matchers: {
                color: /(background|color)$/i,
                date: /Date$/i,
            },
        },
        viewport: {
            viewports: bgsViewports,
            defaultViewport: "mobile",
        },
    },
};

export default preview;
