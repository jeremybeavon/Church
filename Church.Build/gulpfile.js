var gulp = require('gulp');
var tslint = require('gulp-tslint');

var paths = {
    scripts: ['../Church.Web/**/*.ts']
};

gulp.task('default', function () {
    gulp.src(paths.scripts)
    .pipe(tslint())
    .pipe(tslint.report('verbose'));
});