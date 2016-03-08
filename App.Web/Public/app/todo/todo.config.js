(function () {
    'use strict';

    angular.module('todo')
        .constant('TODO_STATUS', {
            inProgress: 1,
            complete: 2
        })
        .config([
            '$urlRouterProvider',
            '$stateProvider',
            onConfig
        ]);

    function onConfig($urlRouterProvider, $stateProvider) {
        console.log('Configuring todo module...');

        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state({
                name: 'root.todo',
                url: '/',
                views: {
                    'content@root': {
                        templateUrl: 'public/app/todo/todo.html',
                        controller: 'TodoCtrl',
                        controllerAs: 'Todo'
                    }
                }
            });
    }
})();