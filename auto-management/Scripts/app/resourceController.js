angular
.module('myApp', [])
    .controller('ResourceController',['$scope', '$http','$compile',
        function ($scope, $http,$compile) {
            $scope.apiModels = {};
            var getResourse = {};
            var entityName = "StudentReg";
            var objectId = "4f55de17-9357-4c16-b7b3-b30590824274";
            $http.get("/api/Resource/GetEntityData/" + entityName + "/" + objectId).success(function (data, status, headers, config) {
               var $table = $('#example').dataTable({
                    "data": data,
                    "columns": [
                        { "title": "Engine" },
                        { "title": "Browser" },
                        { "title": "Platform" },
                        { "title": "" }

                    ]
                });
               $compile($table)($scope);
               // $scope.$apply();
            });
            $scope.openEntity = function (objectID) {
                $http.get("/api/Resource/Get/" + entityName + "/" + objectID).success(function (data, status, headers, config) {
                    $.each(data.controlModelList, function (i, entity) {
                        $scope.apiModels[entity.id] = entity.value;
                    })
                    $scope.apiModels["formId"] = data.formId;
                    $scope.apiModels["entityDefinationId"] = data.entityDefinationId;
                    $scope.apiModels["objectId"] = data.objectId;
                    $scope.apiControls = data;

                }).error(function (data, status, headers, config) {
                    $scope.Error = "Oops... something went wrong";
                    $scope.working = false;
                });
            }

            $scope.saveEntity = function () {
                $http.post("/api/Resource", $scope.apiModels).success(function (data, status, headers, config) {
                    $("#abc").modal("hide");
                }).error(function (data, status, headers, config) {
                    $scope.Error = "Oops... something went wrong";
                    $scope.working = false;
                });

            }
        }]);

