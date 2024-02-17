import { defineConfig } from "vite"
import path from "path";
import svgr from "vite-plugin-svgr";
import react from "@vitejs/plugin-react-swc"
import sassGlobImports from "vite-plugin-sass-glob-import";

// https://vitejs.dev/config/
export default defineConfig({
    resolve: {
        alias: {
            "@pages": path.resolve(__dirname, "./src/pages"),
            "@widgets": path.resolve(__dirname, "./src/widgets"),
            "@features": path.resolve(__dirname, "./src/features"),
            "@entities": path.resolve(__dirname, "./src/entities"),
            "@shared": path.resolve(__dirname, "./src/shared"),
        },
    },
    plugins: [
        svgr(),
        react(),
        sassGlobImports(),
    ],
    server: {
        port: 3000,
        proxy: {
            '/api': {
                target: 'https://localhost:5001',
                secure: false,
            },
        },
    },
});
