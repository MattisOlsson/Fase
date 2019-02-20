/* eslint-disable */

const gulp = require('gulp');

const paths = {
    jsSrc: ['./components/**/*.{js,jsx}', './core/**/*.{js,jsx}', './index.js', './manager.js'],
    scssSrc: ['./components/**/*.scss', './core/**/*.scss', './*.scss'],
    cssSrc: ['./components/**/*.css', './core/**/*.css'],
};

//== ESLint
gulp.task('eslint', require('./gulp-tasks/eslint')(gulp, paths.jsSrc));

//== Stylelint
gulp.task('stylelint:scss', require('./gulp-tasks/stylelint-scss')(gulp, paths.scssSrc));
gulp.task('stylelint:css', require('./gulp-tasks/stylelint-css')(gulp, paths.cssSrc));
gulp.task('stylelint', ['stylelint:scss', 'stylelint:css']);

//== Watchers
gulp.task('watch', function () {
    gulp.watch(paths.jsSrc, ['eslint', 'js:dev', 'js:manager:dev']);
    gulp.watch(paths.scssSrc, ['css:dev', 'manager:dev', 'stylelint:scss']);
    gulp.watch(paths.cssSrc, ['css:dev', 'manager:dev', 'stylelint:css']);
});

gulp.task('css:dev', require('./gulp-tasks/css')(gulp, {
    env: 'development',
    src: './index.scss',
    dest: '../wwwroot/public',
    filename: 'index.css'
}));

gulp.task('css', require('./gulp-tasks/css')(gulp, {
    env: 'production',
    src: './index.scss',
    outputStyle: 'compressed',
    dest: '../wwwroot/public',
    filename: 'index.css'
}));

gulp.task('manager:dev', require('./gulp-tasks/css')(gulp, {
    env: 'development',
    src: './manager.scss',
    dest: '../wwwroot/public',
    filename: 'manager.css'
}));

gulp.task('manager', require('./gulp-tasks/css')(gulp, {
    env: 'production',
    src: './manager.scss',
    outputStyle: 'compressed',
    dest: '../wwwroot/public',
    filename: 'manager.css'
}));

gulp.task('js:dev', require('./gulp-tasks/js')(gulp, {
    env: 'development',
    src: './index.js',
    dest: '../wwwroot/public',
    filename: 'index.js'
}));

gulp.task('js', require('./gulp-tasks/js')(gulp, {
    env: 'production',
    uglify: true,
    src: './index.js',
    dest: '../wwwroot/public',
    filename: 'index.js'
}));

gulp.task('js:manager:dev', require('./gulp-tasks/js')(gulp, {
    env: 'development',
    src: './manager.js',
    dest: '../wwwroot/public',
    filename: 'manager.js'
}));

gulp.task('js:manager', require('./gulp-tasks/js')(gulp, {
    env: 'production',
    uglify: true,
    src: './manager.js',
    dest: '../wwwroot/public',
    filename: 'manager.js'
}));

gulp.task('default', ['css:dev', 'manager:dev', 'js:dev', 'js:manager:dev', 'eslint', 'stylelint', 'watch']);
gulp.task('build', ['css', 'manager', 'js', 'js:manager']);