/* eslint-disable */

const stylelint = require('gulp-stylelint'),
    syntax_scss = require('postcss-scss');

module.exports = function (gulp, paths) {
    return function () {
        return gulp.src(paths)
            .pipe(stylelint({
                failAfterError: true,
                reporters: [{
                    formatter: 'string',
                    console: true,
                    syntax: syntax_scss
                }]
            }));
    };
};