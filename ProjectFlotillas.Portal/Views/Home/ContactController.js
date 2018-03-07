
console.log("contact");

angular.module("projectFlotillas").register.controller('contactController', ['$routeParams', '$location', function ($routeParams, $location) {

    "use strict";

    var vm = this;

    this.initializeController = function () {
        vm.title = "Contact Page";
    }

}]);

