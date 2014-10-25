'use strict';

var underscore = angular.module('underscore', []).factory('_', function () {
    return window._;
});

var autoApp = angular.module('AutoApp',[]);