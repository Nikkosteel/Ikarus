﻿
console.log("index");

angular.module("projectFlotillas").register.controller('indexController', ['$routeParams', '$location', function ($routeParams, $location) {

    "use strict";

    var vm = this;

    this.initializeController = function () {
        vm.title = "Index Page";
    }

}]);


