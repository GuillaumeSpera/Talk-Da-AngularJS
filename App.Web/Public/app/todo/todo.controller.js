(function () {
    'use strict';

    angular.module('todo')
        .controller('TodoCtrl', [
            'Todos',
            'TODO_STATUS',
            TodoController
        ]);

    function TodoController(Todos, TODO_STATUS) {
        var that = this;

        this.newTodoTitle = '';

        this.todoCollection = [];
        this.TODO_STATUS = TODO_STATUS;
        this.statusFilter = null;
        this.removeTodo = removeTodo;
        this.onStatusChange = onStatusChange;
        this.addTodo = addTodo;
        this.switchFilter = switchFilter;

        initialize();

        function initialize() {
            getTodos();
        }

        function getTodos() {
            Todos.getTodos()
                .then(function (todos) {
                    todos.forEach(function (item) {
                        that.todoCollection.push(item);
                    })
                })
                .catch(function (err) {
                    console.warn(err); // Faire la gestion d'erreurs
                });
        }

        function removeTodo(todo) {
            Todos.removeTodo(todo)
                .then(function (todos) {
                    that.todoCollection.splice(0, that.todoCollection.length);

                    todos.forEach(function (item) {
                        that.todoCollection.push(item);
                    })
                });
        }

        function onStatusChange(todo) {
            Todos.editTodo(todo);
        }

        function addTodo() {
            if (this.newTodoTitle.trim() === '') {
                return;
            }

            Todos.createTodo(this.newTodoTitle)
                .then(function (newTodo) {
                    if (angular.isDefined(newTodo) && newTodo !== null) {
                        that.todoCollection.push(newTodo);
                    }
                })
                .finally(function () {
                    that.newTodoTitle = '';
                });
        }

        function switchFilter(status) {
            this.statusFilter = status;
        }
    }
})();