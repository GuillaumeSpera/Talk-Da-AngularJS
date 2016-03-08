(function () {
    'use strict';

    angular.module('storage', [])
        .factory('Storage', [
            '$q',
            storageFactory
        ]);

    function storageFactory($q) {
        var isSupported = function () {
            return (localStorage);
        };

        var storage = {
            retrieveData: retrieveData,
            clearData: clearData,
            containsKey: containsKey,
            storeData: storeData,
            removeData: removeData
        };

        return storage;

        // Méthode de récupération d'une donnée dans le local storage
        function retrieveData(key) {
            if (!isSupported() || !localStorage.length) {
                return $q.reject();
            }

            var stringData = localStorage.getItem(key);
            if (angular.isUndefined(stringData) || stringData === null) {
                return $q.resolve(null);
            }

            try {
                return $q.resolve(JSON.parse(stringData));
            }
            catch (err) {
                storage.removeData(key);

                return $q.reject(err);
            }
        }

        // Méthode permettant de vérifier si une clé existe
        function containsKey(key) {
            if (!isSupported() || !localStorage.length || localStorage.length == 0) {
                return $q.reject('Unable to access storage');
            }

            return $q.resolve(localStorage.getItem(key) != null);
        }

        // Méthode de stockage d'une donnée dans le local storage
        function storeData(key, data) {
            if (!isSupported()) {
                return $q.reject('Unable to access storage');
            }

            // Log Exceptions
            var stringData = JSON.stringify(data);
            localStorage.setItem(key, stringData);
            return $q.resolve();
        }

        // Méthode de suppression d'une donnée dans le local storage
        function removeData(key) {
            if (!isSupported()) {
                return $q.reject('Unable to access storage');
            }

            localStorage.removeItem(key);
            return $q.resolve();
        }

        // Méthode de clean des données du local storage
        function clearData() {
            localStorage.clear();
        }
    }
})();