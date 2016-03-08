(function () {
    'use strict';

    angular.module('about')
        .config([
            '$stateProvider',
            onConfig
        ]);

    function onConfig($stateProvider) {
        $stateProvider
            .state({
                name: 'about',
                url: '/About',
                templateUrl: 'public/app/about/about.html'
            })
    }
})();