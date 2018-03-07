//
//  angular bootup and routing table
//


console.log("Project Flotillas Bootstrap");

(function () {

    var app = angular.module('projectFlotillas', ['ngRoute', 'ui.bootstrap', 'ngSanitize', 'blockUI']);

    app.config(['$controllerProvider', '$provide', function ($controllerProvider, $provide) {
        app.register =
          {
              controller: $controllerProvider.register,
              service: $provide.service
          };
    }]);

})();

console.log("Project Flotillas Bootstrap FINISHED 2");




