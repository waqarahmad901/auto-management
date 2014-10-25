angular
.module('myApp', [])
    .controller('ResourceController',
        function ($scope, $http) {
        $http.get("/api/Resource").success(function (data, status, headers, config) {
            var html = "";
            $.each(data, function (i, control) {
                html += "<div class=\"form-group\">";
                html += "<label title=\"" + control.label + " \" class=\"col-sm-3 control-label\">" + control.label + "</label>"
                html += "<div class=\"col-sm-9\">";
                switch (control.type) {
                    case "textbox":
                        html += "<input type=\"text\" id=\"" + control.name + "\"  ng-model=\"entity." + control.name + "\" class=\"form-control\" />"
                        break;
                    case "dropdown":
                        html += "<select  id=\"" + control.name + "\"  ng-model=\"entity." + control.name + "\" class=\"form-control\" >";
                        for (di = 0; di < control.values.length; di++) {
                            html += "<option value=\"" + control.values[di] + "\">" + control.values[di] + "</option>"
                        }
                        html += "</select>";
                        break;
                    case "radio":
                        for (di = 0; di < control.values.length; di++) {
                            html += "<input type=\"radio\" name=\"" + control.name + "\"  ng-model=\"entity." + control.name + "\" value=\"" + control.values[di] + "\">" + control.values[di];
                        }
                        break;
                    case "checkbox":
                        for (di = 0; di < control.values.length; di++) {
                            html += "<input type=\"checkbox\" name=\"" + control.name + "\"  ng-model=\"entity." + control.name + "\" value=\"" + control.values[di] + "\">" + control.values[di];
                        }
                        break;

                }
                html += "</div>";
                html += "</div>";

            });

            $(".html").html(html);

        }).error(function (data, status, headers, config) {
            $scope.Error = "Oops... something went wrong";
            $scope.working = false;
        });

    });

