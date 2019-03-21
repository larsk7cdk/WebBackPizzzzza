/// <binding BeforeBuild='Run - Development' />
const path = require("path");

module.exports = {
    entry: path.join(__dirname, "/scripts/app.ts"),
    output: {
        filename: "app.js",
        path: __dirname + "/wwwroot/dist"
    },
    mode: "development",
    module: {
        rules: [
            {
                test: /\.ts?$/,
                loader: "ts-loader",
                exclude: [
                    /node_modules/,
                    /wwwroot/
                ]
            }
        ]
    },
    resolve: {
        extensions: [".ts", ".js"]
    }
};