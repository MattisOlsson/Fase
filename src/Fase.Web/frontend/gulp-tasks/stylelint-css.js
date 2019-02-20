/* eslint-disable */

const stylelint = require('gulp-stylelint');

module.exports = function (gulp, paths) {
    return function () {
        return gulp.src(paths)
            .pipe(stylelint({
                failAfterError: true,
                reporters: [{
                    formatter: 'string',
                    console: true
                }]
            }));
    };
};