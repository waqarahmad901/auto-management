//'use strict';

//autoApp.controller('StudentController1', ['$scope', '$http', function ($scope, $http) {
//        $http.get("/api/Student").success(function (data, status, headers, config) {
//            $scope.students = data;
//        }).error(function (data, status, headers, config) {
//            $scope.Error = "Oops... something went wrong";
//            $scope.working = false;
//        });

//        $scope.saveStudent = function (student) {
//            $scope.working = true;
//            $scope.answered = true;

//            $http.post('/api/Student', student).success(function (data, status, headers, config) {
//                $scope.students.push(student);
//                $scope.student = {};
//            }).error(function (data, status, headers, config) {
//                $scope.Error = "Oops... something went wrong";
               
//            });
//        };
//    }]); 