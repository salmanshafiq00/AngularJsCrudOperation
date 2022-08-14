(function () {
    'use strict';

    angular.module('app', [
        'ngRoute'

    ])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

            $locationProvider.hashPrefix('');

            $routeProvider
                .when('/', {
                    controller: 'StudentCtrl',
                    templateUrl: 'app/templates/students.html'
                })
                .when('/addStudent', {
                    controller: 'studentAddCtrl',
                    templateUrl: 'app/templates/studentAdd.html'
                })
                .when('/editStudent/:Id', {
                    controller: 'studentEditCtrl',
                    templateUrl: 'app/templates/studentEdit.html'
                })
                .otherwise({ redirectTo: '/' });
        }]);
})();