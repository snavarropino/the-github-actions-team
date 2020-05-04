// Karma configuration file, see link for more information
// https://karma-runner.github.io/1.0/config/configuration-file.html

module.exports = function (config) {
  config.set({
    basePath: '',
    frameworks: ['jasmine', '@angular-devkit/build-angular'],
    plugins: [
      require('karma-jasmine'),
      require('karma-chrome-launcher'),
      require('karma-jasmine-html-reporter'),
      require('karma-coverage-istanbul-reporter'),
      require('@angular-devkit/build-angular/plugins/karma'),
      require('karma-scss-preprocessor'),
      require('karma-junit-reporter')
    ],
    client: {
      clearContext: false// leave Jasmine Spec Runner output visible in browser
    },
    files: [
      {
        pattern: '../node_modules/@angular/material/prebuilt-themes/deeppurple-amber.css',
        included: true,
        watched: true
      },
      {pattern: './test.ts', watched: false},
      {pattern: './app/styles/**/*.*', watched: true, included: true, served: true}
    ],
    preprocessors: {
      './app/styles/**/*.*': ['scss']
    },
    coverageIstanbulReporter: {
      dir: require('path').join(__dirname, '../coverage'),
      reports: ['html', 'lcovonly'],
      fixWebpackSourcePaths: true
    },
    reporters: ['progress', 'kjhtml','junit'],
    junitReporter: {
      outputDir: 'unitTestResults', // results will be saved as $outputDir/$browserName.xml
      outputFile: 'testsResults.xml', // if included, results will be saved as $outputDir/$browserName/$outputFile
      useBrowserName: false, // add browser name to report and classes names
    },
    port: 9876,
    colors: true,
    logLevel: config.LOG_INFO,
    autoWatch: true,
    browsers: ['Chrome'],
    singleRun: false
  });
};
