angular.module('virtoCommerce.orderModule')
.controller('virtoCommerce.orderModule.customerOrderItemsBpWidgetController', ['$scope', '$translate', 'platformWebApp.bladeNavigationService',
    function ($scope, $translate, bladeNavigationService) {
    var blade = $scope.widget.blade;
    
    $scope.$watch('widget.blade.customerOrder', function (operation) {
        $scope.operation = operation;
    });

    $scope.openItemsBlade = function () {

        var newBlade = {
            id: 'customerOrderItems',
            currentEntity: $scope.operation,
            recalculateFn: blade.recalculate,
            controller: 'virtoCommerce.orderModule.customerOrderItemsBpController',
            template: 'Modules/$(VirtoCommerce.Orders)/Scripts/blades/customerOrder-items-bp.tpl.html'
        };
        bladeNavigationService.showBlade(newBlade, blade);
    };

}]);
