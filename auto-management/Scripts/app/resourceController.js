angular
.module('myApp', [])
    .controller('ResourceController',
        function ($scope, $http) {
            $scope.apiModels = {};
            $scope.apiModels["drpAbc"] = "Select";
            $http.get("/api/Resource").success(function (data, status, headers, config) {
                $.each(data.controlModelList, function (i, entity) {
                    $scope.apiModels[entity.id] = entity.value;
                })
                $scope.apiModels["formId"] = data.formId ;
                $scope.apiControls = data;

            }).error(function (data, status, headers, config) {
                $scope.Error = "Oops... something went wrong";
                $scope.working = false;
            });

            $scope.saveEntity = function () {
                $http.post("/api/Resource", $scope.apiModels).success(function (data, status, headers, config) {
            

                }).error(function (data, status, headers, config) {
                    $scope.Error = "Oops... something went wrong";
                    $scope.working = false;
                });

            }
        });

