const { merge } = require("webpack-merge");
const common = require('./webpack.common.js');
const path = require("path");

module.exports = merge(common, {
    mode: "development",
    devtool: "inline-source-map",
    output: {
        filename: "main.js",
        path: path.resolve(__dirname, "dist"),
    },
    devServer: {
        port: 3000,
        static: {
            directory: "./src",
            watch: {
                ignored: ["**/node_modules/", "**/dist/**"],
            },
        },
        historyApiFallback: true,
        proxy: {
            "/api": {
                target: "https://localhost:5001",
                secure: false
            }
        }
    }
})