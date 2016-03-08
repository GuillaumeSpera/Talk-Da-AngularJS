(function () {
    'use strict';

    angular.module('todo', [])
        .constant('TODO_STATUS', {
            inProgress: 1,
            complete: 2
        })
        .config([
            '$urlRouterProvider',
            '$locationProvider',
            '$stateProvider',
            onConfig
        ]);

    function onConfig($urlRouterProvider, $locationProvider, $stateProvider) {
        console.log('Configuring todo module...');

        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state({
                name: 'root.todo',
                url: '/',
                templateUrl: 'public/app/todo/todo.html',
                controller: 'TodoCtrl'
            })
            .state({
                name: 'root.todoCreate',
                url: '/Create',
                templateUrl: 'public/app/todo/todoCreate.html'
            })
            .state({
                name: 'root.todoEdit',
                url: '/Edit',
                templateUrl: 'public/app/todo/todoEdit.html'
            });
    }
})();


(function () {
    'use strict';

    angular.module('myApp', []); // Création du module
})();


(function () {
    'use strict';

    angular.module('myApp'); // Récupération du module
})();
