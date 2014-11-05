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
                        if (entity.type == "checkbox")
                            $scope.apiModels[entity.id] = entity.value.split(",");
                        else
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
                var tempArray = {};
                $.each($scope.apiModels, function (i, entity) {
                    if ($scope.apiModels[i] instanceof Array)
                        tempArray[i] = $scope.apiModels[i].join();
                    else
                        tempArray[i] = $scope.apiModels[i]
                })
                $http.post("/api/Resource", tempArray).success(function (data, status, headers, config) {
                    $("#abc").modal("hide");
                    drawTable(entityName, $http, $compile, $scope);
                }).error(function (data, status, headers, config) {
                    $scope.Error = "Oops... something went wrong";
                    $scope.working = false;
                });

            }

            $scope.toggleSelection = function (checkboxId, value) {
                if ($scope.apiModels[checkboxId] == "")
                    $scope.apiModels[checkboxId] = [];
                var idx = $scope.apiModels[checkboxId].indexOf(value);
                if (idx > -1) {
                    $scope.apiModels[checkboxId].splice(idx, 1);
                }
                else {
                    $scope.apiModels[checkboxId].push(value);
                }
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

