/* eslint-disable */

const sass = require('gulp-sass');
const concat = require('gulp-concat');
const sourcemaps = require('gulp-sourcemaps');
const postcss = require('gulp-postcss');
const autoprefixer = require('autoprefixer');
const pxtorem = require('postcss-pxtorem');
const defaults = {
    src: null,
    dest: null,
    filename: null,
    outputStyle: 'compact'
};

module.exports = function(gulp, options){
    options = Object.assign({}, defaults, options);
    return function(){
        return gulp.src(options.src)
            .pipe(sourcemaps.init())
            .pipe(sass({ outputStyle: options.outputStyle, precision: 6 }).on('error', sass.logError))
            .pipe(concat(options.filename))
            .pipe(postcss([
                autoprefixer({ browsers: ['last 5 versions', '> 1%', 'ie 9', 'ie 8'] }),
                pxtorem({
                    root_value: 16,
                    replace: true,
                    propWhiteList: ['font', 'font-size', 'line-height', 'letter-spacing'],
                    media_query: true
                })
            ]))
            .pipe(sourcemaps.write('.'))
            .pipe(gulp.dest(options.dest));
    };
};