## Table of contents

- [Quick start](#quick-start)
- [What's included](#whats-included)


## Quick start

**Warning**

> Verify that you are running at least node 8.9.x and npm 5.x.x by running node -v and npm -v in a terminal/console window. Older versions produce errors, but newer versions are fine.

1. Go to project folder and install dependencies.
 ```bash
 npm i
 ```

2. Launch development server:
 ```bash
 npm start
 ```

**Note**

> You don't need to build the example library because it's published in npm and added as dependency of the project.

## What's included

* CRUD: create, update and remove heroes with Firebase!
* Search bar, to look for heroes
* Custom loading page
* Modal and toasts (snakbar)!
* Internationalization with ng-translate and ngx-translate-extract. Also use cache busting for translation files with [webpack translate loader](https://github.com/ngx-translate/http-loader#angular-cliwebpack-translateloader-example)
* Automatic translate script with Google Translate oO
* Lazy loading modules
* Service Workers
* Dynamic Imports
* Storage module (ngx-store)
* More logical structure directory (from [here](https://itnext.io/choosing-a-highly-scalable-folder-structure-in-angular-d987de65ec7))
* Basic example library
* Scroll restoration and anchor examples
* Responsive layout (flex layout module)
* SASS (most common used functions and mixins) and BEM styles
* Animations!
* Angular Pipes
* Interceptors and Events (Progress bar active, if a request is pending)
* Scroll to first invalid input in forms. ([ngx-scroll-to-first-invalid](https://github.com/Ismaestro/ngx-scroll-to-first-invalid))
* Autocomplete enabled in forms
* Modernizr (browser features detection)
* Browser filter (Bowser) for IE ^^
* [Sentry](https://sentry.io)! (logs any error in the app)
* Google Tag Manager
* Unit tests with Jasmine and Karma including code coverage
* End-to-end tests with Protractor
* ES6 Promises and Observables
* Following the [best practices](https://angular.io/guide/styleguide)!

Tasks                    | Description
-------------------------|---------------------------------------------------------------------------------------
npm i                    | Install dependencies
npm start                | Start the app in development mode
npm run test             | Run unit tests with karma and jasmine
npm run test-headless    | Run unit tests in Headless mode
npm run e2e              | Run end to end tests with protractor
npm run e2e-az           | Run end to end tests with protractor with no webdriver update (for azure devops)
npm run build            | Build the app for production
npm run lint             | Run the linter (tslint)
npm run ci               | Execute linter and tests
npm run extract          | Generate all json files with the translations in assets folder
npm run translate        | Translate all keys remaining using Google Translate and using English language as the origin
npm run deploy           | Build the app and deploy it to firebase hosting
npm run bundle-report    | Build and run webpack-bundle-analyzer over stats json
npm run release          | Create a new release using standard-version
npm run docker           | Build the docker image and run the container
npm run update           | Update the project dependencies with ng update

### Docker

You can build the image and run the container with Docker. The configuration is in the nginx folder if you want to change it.

`docker build -t angularexampleapp .`

`docker run -d -p 4200:80 angularexampleapp`

