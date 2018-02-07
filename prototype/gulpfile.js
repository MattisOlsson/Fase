/* eslint-disable */

const gulp = require('gulp');

const paths = {
    jsSrc: ['./components/**/*.{js,jsx}', './core/**/*.{js,jsx}', './index.js'],
    scssSrc: ['./components/**/*.scss', './core/**/*.scss', './*.scss'],
    cssSrc: ['./components/**/*.css', './core/**/*.css'],
    ejsSrc: ['./pages/*.ejs', './components/**/*.ejs']
};

//== ESLint
gulp.task('eslint', require('./gulp-tasks/eslint')(gulp, paths.jsSrc));

//== Stylelint
gulp.task('stylelint:scss', require('./gulp-tasks/stylelint-scss')(gulp, paths.scssSrc));
gulp.task('stylelint:css', require('./gulp-tasks/stylelint-css')(gulp, paths.cssSrc));
gulp.task('stylelint', ['stylelint:scss', 'stylelint:css']);

//== Watchers
gulp.task('watch', function () {
    gulp.watch(paths.jsSrc, ['eslint', 'js:dev']);
    gulp.watch(paths.scssSrc, ['css:dev', 'stylelint:scss']);
    gulp.watch(paths.cssSrc, ['css:dev', 'stylelint:css']);
    gulp.watch(paths.ejsSrc, ['prototype']);
});

gulp.task('css:dev', require('./gulp-tasks/css')(gulp, {
    env: 'development',
    src: './index.scss',
    dest: 'public',
    filename: 'index.css'
}));

gulp.task('css', require('./gulp-tasks/css')(gulp, {
    env: 'production',
    src: './index.scss',
    outputStyle: 'compressed',
    dest: 'public',
    filename: 'index.css'
}));

gulp.task('js:dev', require('./gulp-tasks/js')(gulp, {
    env: 'development',
    src: './index.js',
    dest: 'public',
    filename: 'index.js'
}));

gulp.task('js', require('./gulp-tasks/js')(gulp, {
    env: 'production',
    uglify: true,
    src: './index.js',
    dest: 'public',
    filename: 'index.js'
}));

gulp.task('prototype', require('./gulp-tasks/prototype')(gulp));
gulp.task('default', ['css:dev', 'js:dev', 'prototype', 'eslint', 'stylelint', 'watch']);
gulp.task('build', ['css', 'js']);