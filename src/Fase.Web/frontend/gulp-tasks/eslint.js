/* eslint-disable */

const eslint = require('gulp-eslint');
const eslintrcPath = './.eslintrc';

module.exports = function (gulp, paths) {
    return function () {
        return gulp.src(paths)
            .pipe(eslint(eslintrcPath))
            .pipe(eslint.format())
            .pipe(eslint.failAfterError());
    };
};