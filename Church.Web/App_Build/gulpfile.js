var gulp = require('gulp');
var tslint = require('gulp-tslint');

var paths = {
    scripts: ['../Default.ts', '../Pages/**/*.ts', '../Scripts/Common/*.ts']
    //scripts: ['../**/*.ts']
};

gulp.task('default', function () {
    gulp.src(paths.scripts, { base: '../' })
    .pipe(tslint())
    .pipe(tslint.report('verbose'));
});