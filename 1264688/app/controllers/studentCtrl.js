(function () {
    'use strict';

    angular
        .module('app')
        .controller('StudentCtrl', ['$scope', 'dataService', function ($scope, dataService) {
            $scope.students = [];
            getData();
            function getData() {
                dataService.getStudents().then(function (result) {
                    $scope.students = result;
                });
            };
            $scope.ToDate = function (d) {
                var dateShow = Number(d.slice(6, 19));
                return new Date(dateShow);
            }

            $scope.deleteStudent = function (Id) {
                dataService.deleteStudent(Id).then(function () {
                    getData();
                })
            }
        }])
        .controller('studentAddCtrl', ['$scope', '$location', 'dataService', function ($scope, $location, dataService) {
            $scope.department = [];
            getDept();
            function getDept() {
                dataService.getDeptList().then(function (result) {
                    $scope.department = result;
                });
            };
            $scope.createStudent = function (student) {
                dataService.addStudent(student).then(function () {
                    $location.path('/');
                });
            };
        }])
        .controller('studentEditCtrl', ['$scope', '$routeParams', '$location', 'dataService', function ($scope, $routeParams, $location, dataService) {
            $scope.student = {};
            dataService.getStudentById($routeParams.Id).then(function (result) {
                $scope.student = result;
            });
            $scope.updateStudent = function (student) {
                dataService.editStudent(student).then(function () {
                    $location.path('/');
                });
            }
        }]);

})();
