(function () {
    'use strict';

    angular.module('myApp')
        .config([
            '$locationProvider',
            '$stateProvider',
            onConfig
        ])
        .run(onRun);

    function onConfig($locationProvider, $stateProvider) {
        console.log('Configuring application...');

        $stateProvider
            .state({
                name: 'root',
                abstract: true,
                url: '',
                templateUrl: 'public/app/app.html'
            });

        $locationProvider.html5Mode(true);
    }

    function onRun() {
        console.log('Application started...');
    }
})();