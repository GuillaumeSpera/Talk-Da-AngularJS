(function () {
    'use strict';

    // # Module Configuration
    angular.module('myApp')
        .config(appConfig)
        .run(appRun);

    function appConfig() {
        console.log('Configuring application...');
    }

    function appRun() {
        console.log('Application started...');
    }
})();