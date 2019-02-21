const webpack = require('webpack');
const merge = require('webpack-merge');
const common = require('./webpack.common.js');

module.exports = merge(common, {
    devtool: "inline-source-map",
    watch: true,
    plugins: [
        new webpack.LoaderOptionsPlugin({
          debug: true
        }),
        new webpack.DefinePlugin({
            'process.env': {
                NODE_ENV: JSON.stringify('development')
            }
        })
      ]
});