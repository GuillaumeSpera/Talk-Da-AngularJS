(function () {
    'use strict';

    angular.module('todo')
        .filter('statusFilter', statusFilter);

    // Filter on chosen status
    function statusFilter() {
        return function (todoCollection, status) {
            if (angular.isUndefined(status) || status === null) {
                return todoCollection;
            }

            var result = [];

            if (angular.isArray(todoCollection)) {
                todoCollection.forEach(function (item) {
                    if (item.hasOwnProperty('status') && item.status === status) {
                        result.push(item);
                    }
                });
            }

            return result;
        }
    }
})();