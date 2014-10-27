angular
.module('myApp', [])
    .controller('ResourceController',['$scope', '$http',
        function ($scope, $http) {
            $scope.apiModels = {};
            $scope.apiModels["drpAbc"] = "Select";
            $http.get("/api/Resource").success(function (data, status, headers, config) {
                $scope.apiControls = data;
            }).error(function (data, status, headers, config) {
                $scope.Error = "Oops... something went wrong";
                $scope.working = false;
            });

            $scope.saveEntity = function () {
                alert($scope.apiModels);
            }
        }]);

