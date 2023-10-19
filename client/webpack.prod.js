const { merge } = require("webpack-merge");
const common = require('./webpack.common.js');
const path = require("path");

module.exports = merge(common, {
    mode: "production",
    bail: true,
    output: {
        path: path.join(__dirname, "dist"),
        filename: "[name].[contenthash].bundle.js",
        clean: true,
    }
})