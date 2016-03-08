(function () {
    'use strict';

    angular.module('todo')
        .factory('Todos', ['TODO_STATUS', 'Storage', todoFactory]);

    // Use todoStatus on create
    // Use Storage as storage service for todo entities
    function todoFactory(TODO_STATUS, Storage) {
        return {};
    }
})();