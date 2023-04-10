const path = require("path")

module.exports = {
  entry: "./src/App.fs.js",
  output: {
    path: path.resolve(__dirname, "dist")
  },
  devServer: {
    static: "./dist",
    host: "0.0.0.0"
  },
  module: {
    rules: [
      
    ]
  }
}
