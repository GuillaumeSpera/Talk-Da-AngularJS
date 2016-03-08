(function () {
    'use strict';

    angular.module('todo')
        .filter('statusFilter', ['TODO_STATUS', statusFilter]);

    // Filter on chosen status
    function statusFilter(TODO_STATUS) {

    }
})();