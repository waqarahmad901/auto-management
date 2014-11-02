angular
.module('myApp', [])
    .controller('ResourceController',['$scope', '$http','$compile',
        function ($scope, $http,$compile) {
            $scope.apiModels = {};
            var getResourse = {};
            var entityName = "StudentReg";
            
            drawTable(entityName,$http,$compile,$scope);
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
                    drawTable(entityName, $http, $compile, $scope);
                }).error(function (data, status, headers, config) {
                    $scope.Error = "Oops... something went wrong";
                    $scope.working = false;
                });

            }
        }]);

function drawTable(entityName,$http,$compile,$scope)
{
    $http.get("/api/Resource/GetEntityData/" + entityName).success(function (data, status, headers, config) {
        var headers = [];
        for (var i = 0; i < data.headers.length; i++) {
            var obj = { "title": data.headers[i] };
            headers.push(obj);
        }
        var obj = {
            "title": "<a style='text-align:center' href=\"#\" data-toggle=\"modal\" data-target=\"#abc\" ng-click=\"openEntity('empty')\">Add</a>",
            sorting: false,
            "class": "center"
        }
        headers.push(obj);
        if ($.fn.dataTable.isDataTable('#example')) {
            table = $('#example').DataTable().destroy();
        }
        var $table = $('#example').dataTable({
            "data": data.lists,
            "paging": false,
            "columns": headers

        });
        $compile($table)($scope);

    });
}

