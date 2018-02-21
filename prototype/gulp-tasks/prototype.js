const gutil = require('gulp-util');
const fs = require('fs');
const ejs = require('gulp-ejs');
const extend = require('extend');
const rename = require('gulp-rename');

let uniqueId = 0;
const pageDirectory = './pages/';

const fileExtensionIsEjs = fileName => fileName.indexOf('.ejs') !== -1;

const fileExtensionToHtml = fileName => fileName.split('.').shift() + '.html';

module.exports = function(gulp){
    return function(){
        let models = {};
        models.extend = extend;
        models.find = (array, check) => array.filter(check)[0];
        models.uniqueId = () => uniqueId++;
        models.pages = fs.readdirSync(pageDirectory)
            .filter(fileExtensionIsEjs)
            .map(fileExtensionToHtml);
        gulp.src('./pages/*.ejs')
            .pipe(ejs(models).on('error', gutil.log))
            .pipe(rename({extname: '.html'}))
            .pipe(gulp.dest('../src/Fase.Web/'));
    };
};