(function () {
    'use strict';

    angular.module('user')
        .directive('userProfile', userProfile);

    // Component syntax
    function userProfile() {
        return {};
    }
})();