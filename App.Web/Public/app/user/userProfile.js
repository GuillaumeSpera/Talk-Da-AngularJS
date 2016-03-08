(function () {
    'use strict';

    angular.module('user')
        .directive('userProfile', ['$http', userProfile]);

    // Component syntax
    function userProfile($http) {
        return {
            restrict: 'E',
            scope: true,
            templateUrl: 'public/app/user/userProfile.html',
            link: function (scope, element, attributes) {
                $http.get('api/user')
                    .then(function (response) {
                        scope.userName = response.data.userName;
                    })
                    .catch(function () {
                        scope.userName = 'hum... who are you ?'
                    });
            }
        }
    }
})();