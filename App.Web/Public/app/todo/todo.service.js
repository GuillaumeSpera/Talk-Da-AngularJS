(function () {
    'use strict';

    angular.module('todo')
        .factory('Todos', [
            'TODO_STATUS',
            'Storage',
            '$q',
            todoFactory
        ]);

    // Use todoStatus on create
    // Use Storage as storage service for todo entities
    function todoFactory(TODO_STATUS, Storage, $q) {
        var storageKey = 'todo';

        return {
            getTodos: getTodos,
            createTodo: createTodo,
            editTodo: editTodo,
            removeTodo: removeTodo
        };

        function getTodos() {
            return Storage.retrieveData(storageKey)
                .then(function (data) {
                    if (angular.isArray(data)) {
                        return $q.resolve(angular.copy(data));
                    }

                    return $q.reject();
                });
        }

        function createTodo(title) {
            if (angular.isString(title) === false || title.trim() === '') {
                return $q.reject();
            }

            var todoCollection = [];
            var todo = {
                id: new Date().getTime(),
                title: title,
                status: TODO_STATUS.inProgress
            };

            this.getTodos()
                .then(function (todos) {
                    todoCollection = todos;
                })
                .finally(function () {
                    todoCollection.push(todo);

                    saveTodoCollection(todoCollection);
                });

            return $q.resolve(todo);
        }

        function saveTodoCollection(todoCollection) {
            Storage.storeData(storageKey, todoCollection);
        }

        function editTodo(todo) {
            return this.getTodos()
                .then(function (todos) {
                    for (var idx = 0; idx < todos.length; idx++) {
                        if (todos[idx].id === todo.id) {
                            todos[idx].status = todo.status;
                            todos[idx].title = todo.title;

                            saveTodoCollection(todos);

                            return $q.resolve(todos[idx]);
                        }
                    }

                    $q.reject();
                });
        }

        function removeTodo(todo) {
            return this.getTodos()
                .then(function (todos) {
                    for (var idx = 0; idx < todos.length; idx++) {
                        if (todos[idx].id === todo.id) {
                            todos.splice(idx, 1);
                            break;
                        }
                    }

                    saveTodoCollection(todos);

                    return $q.resolve(todos);
                });
        }
    }
})();