;(function (angular) {
    'use strict';

    var app = angular.module('app', [
        // ThirdParty
        'ui.router',
        // App
        'app.services',
        'app.controllers'
    ]);

    app.config(['$locationProvider', '$stateProvider', '$urlRouterProvider', appConfiguration])
        .run(appRun);

    // # Module Configuration

    function appConfiguration($locationProvider, $stateProvider, $urlRouterProvider) {
        $locationProvider.html5Mode(true);
        $urlRouterProvider.otherwise('/');

        //$stateProvider
        //    // Default route
        //    .state(
        //    {
        //        name: 'root.base',
        //        url: '/',
        //        templateUrl: '',
        //        controller: ''
        //    }
        //);
    }

    function appRun() {
        
    }
})(angular);