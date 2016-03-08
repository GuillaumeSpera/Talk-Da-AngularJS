(function () {
    'use strict';

    angular.module('storage', [])
        .factory('Storage', storageFactory);

    function storageFactory() {
        return {};
    }
})();