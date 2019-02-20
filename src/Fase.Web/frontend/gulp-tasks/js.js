/* eslint-disable */

const path = require('path');
const browserify = require('browserify');
const incremental = require('browserify-incremental');
const intoStream = require('into-stream');
const through2 = require('through2');
const gutil = require('gulp-util');
const concat = require('concat-stream');
const babelify = require('babelify');
const source = require('vinyl-source-stream');
const buffer = require('vinyl-buffer');
const sourcemaps = require('gulp-sourcemaps');
const uglify = require('gulp-uglify');
const gulpif = require('gulp-if');
const env = require('gulp-env');
const bundlers = {};
const defaults = {
    env: null,
    uglify: false,
    sourcemaps: false,
    src: null,
    dest: null,
    filename: null
};
const browserifyOptions = {
    standalone: 'checkout',
    transform: [
        babelify.configure({ presets: ['es2015'] })
    ]
};

function bundle(gulp, options) {
    return through2.obj(function(file, encoding, next) {
        var transform = this;
        const bundler = createBundler(file, transform);
        bundler.bundle()
            .on('error', createErrorHandler(transform))
            .pipe(source(options.filename))
            .pipe(buffer())
            .pipe(gulpif(options.sourcemaps, sourcemaps.init({ loadMaps: true })))
            .pipe(gulpif(options.uglify, uglify()))
            .on('error', gutil.log)
            .pipe(gulpif(options.sourcemaps, sourcemaps.write('.')))
            .pipe(gulp.dest(options.dest))
            .on('end', function(){
                next(null, this);
            })
    });
}

function createBundler(file, transform) {
    browserifyOptions.entries = file.isNull() ? file.path : intoStream(file.contents);
    browserifyOptions.basedir = typeof browserifyOptions.entries !== 'string' ? path.dirname(file.path) : undefined;
    var bundler = bundlers[file.path];
    if(bundler) {
        bundler.removeAllListeners('log');
        bundler.removeAllListeners('time');
    }
    else {
        bundler = browserify(Object.assign(browserifyOptions, incremental.args));
        incremental(bundler);
        bundlers[file.path] = bundler;
    }
    bundler.on('log', message => transform.emit('log', message));
    bundler.on('time', time => transform.emit('time', time));
    return bundler;
}

function createErrorHandler(transform) {
    return error => {
        gutil.log(`'${gutil.colors.cyan('browserify')}' ${gutil.colors.red(error.name)}`);
        gutil.log(error.toString().replace(error.name+': ', ''));
        error.filename && console.log(error.filename);
        error.codeFrame && console.log(error.codeFrame + '\n');
        transform.emit('end');
    }
}

module.exports = function(gulp, options) {
    options = Object.assign({}, defaults, options);
    return function() {
        const envs = env.set({NODE_ENV: options.env});
        return gulp.src(options.src, { read: false })
            .pipe(envs)
            .pipe(bundle(gulp, options));
    };
};