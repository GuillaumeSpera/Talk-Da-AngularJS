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
                name: 'root.about',
                url: '/About',
                views: {
                    'content@root': {
                        templateUrl: 'public/app/about/about.html'
                    }
                }
            })
    }
})();