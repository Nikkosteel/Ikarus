
console.log("product pop up");
angular.module("projectFlotillas").register.controller('productPopUpController',
    ['$routeParams', '$location', 'ajaxService', 'alertService',
        function ($routeParams, $location, ajaxService, alertService) {

            $scope.showModal = false;
            $scope.buttonClicked = "";
            $scope.toggleModal = function (btnClicked) {
                $scope.buttonClicked = btnClicked;
                $scope.showModal = !$scope.showModal;
            };

            this.directive = function () {
                return {
                    template: '<div class="modal fade">' +
                    '<div class="modal-dialog">' +
                    '<div class="modal-content">' +
                    '<div class="modal-header">' +
                    '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                    '<h4 class="modal-title">{{ buttonClicked }} clicked!!</h4>' +
                    '</div>' +
                    '<div class="modal-body" ng-transclude></div>' +
                    '</div>' +
                    '</div>' +
                    '</div>',
                    restrict: 'E',
                    transclude: true,
                    replace: true,
                    scope: true,
                    link: function postLink(scope, element, attrs) {
                        scope.$watch(attrs.visible, function (value) {
                            if (value == true)
                                $(element).modal('show');
                            else
                                $(element).modal('hide');
                        });

                        $(element).on('shown.bs.modal', function () {
                            scope.$apply(function () {
                                scope.$parent[attrs.visible] = true;
                            });
                        });

                        $(element).on('hidden.bs.modal', function () {
                            scope.$apply(function () {
                                scope.$parent[attrs.visible] = false;
                            });
                        });
                    }
                };
            }
        }]);
//angular.module("projectFlotillas").register.controller('productMaintenanceController',
//    ['$routeParams', '$location', 'ajaxService', 'alertService',
//    function ($routeParams, $location, ajaxService, alertService) {

//        "use strict";

//        var vm = this;

//        this.initializeController = function () {

//            vm.title = "Product Maintenance";

//            vm.messageBox = "";
//            vm.alerts = [];

//            var productID = ($routeParams.id || "");

//            if (productID == "") {
//                vm.productID = "0";
//                vm.productName = "";
//                vm.quantityPerUnit = "";
//                vm.unitPrice = "";             
//            }
//            else {
//                vm.productID = productID;
//                var product = new Object();
//                product.productID = productID
//                ajaxService.ajaxPost(product, "api/productService/GetProduct", this.getProductOnSuccess, this.getProductOnError);
//            }

//        }

//        this.closeAlert = function (index) {
//            vm.alerts.splice(index, 1);
//        };

//        this.getProductOnSuccess = function (response) {

//            vm.productName = response.productName;
//            vm.quantityPerUnit = response.quantityPerUnit;
//            vm.unitPrice = response.unitPrice;
          
//        }

//        this.getProductOnError = function (response) {

//        }


//        this.saveProduct = function () {

//            var product = new Object();

//            product.productID = vm.productID
//            product.productName = vm.productName;
//            product.quantityPerUnit = vm.quantityPerUnit;
//            product.unitPrice = vm.unitPrice;         

//            if (product.productID == "0") {
//                ajaxService.ajaxPost(product, "api/productService/CreateProduct", this.createProductOnSuccess, this.createProductOnError);
//            }
//            else {
//                ajaxService.ajaxPost(product, "api/productService/UpdateProduct", this.updateProductOnSuccess, this.updateProductOnError);
//            }

//        }

//        this.createProductOnSuccess = function (response) {
//            vm.clearValidationErrors();
//            alertService.renderSuccessMessage(response.returnMessage);
//            vm.messageBox = alertService.returnFormattedMessage();
//            vm.alerts = alertService.returnAlerts();
//            vm.productID = response.productID;
//        }

//        this.createProductOnError = function (response) {
//            vm.clearValidationErrors();
//            alertService.renderErrorMessage(response.returnMessage);
//            vm.messageBox = alertService.returnFormattedMessage();
//            vm.alerts = alertService.returnAlerts();
//            alertService.setValidationErrors(vm, response.validationErrors);
//        }

//        this.updateProductOnSuccess = function (response) {
//            vm.clearValidationErrors();
//            alertService.renderSuccessMessage(response.returnMessage);
//            vm.messageBox = alertService.returnFormattedMessage();
//            vm.alerts = alertService.returnAlerts();
//        }

//        this.updateProductOnError = function (response) {
//            vm.clearValidationErrors();
//            alertService.renderErrorMessage(response.returnMessage);
//            vm.messageBox = alertService.returnFormattedMessage();
//            vm.alerts = alertService.returnAlerts();
//            alertService.setValidationErrors(vm, response.validationErrors);
//        }

//        this.clearValidationErrors = function () {
//            vm.productNameInputError = false;
//        }

//    }]);
