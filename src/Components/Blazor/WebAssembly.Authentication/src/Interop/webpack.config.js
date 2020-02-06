const path = require('path');

module.exports = {
  entry: './AuthenticationService.ts',
  devtool: 'source-map',
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/,
      },
    ],
  },
  resolve: {
    extensions: [ '.tsx', '.ts', '.js' ],
  },
  output: {
    filename: 'AuthenticationService.js',
    path: path.resolve(__dirname, '..', 'wwwroot'),
  },
};
