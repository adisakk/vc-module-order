angular.module('virtoCommerce.orderModule')
.controller('virtoCommerce.orderModule.shipmentDetailController', ['$window','$scope', 'platformWebApp.bladeNavigationService', 'platformWebApp.dialogService', 'platformWebApp.settings', 'virtoCommerce.orderModule.order_res_customerOrders', 'virtoCommerce.orderModule.order_res_fulfilmentCenters', 'virtoCommerce.orderModule.statusTranslationService', 'platformWebApp.authService',
    function ($window, $scope, bladeNavigationService, dialogService, settings, customerOrders, order_res_fulfilmentCenters, statusTranslationService, authService) {
        var blade = $scope.blade;

        blade.isVisiblePrices = authService.checkPermission('order:read_prices');

        if (blade.isNew) {
            blade.title = 'orders.blades.shipment-detail.title-new';

            var foundField = _.findWhere(blade.metaFields, { name: 'createdDate' });
            if (foundField) {
                foundField.isReadonly = false;
            }

            customerOrders.getNewShipment({ id: blade.customerOrder.id }, blade.initialize);
        } else {
            blade.title = 'orders.blades.shipment-detail.title';
            blade.titleValues = { number: blade.currentEntity.number };
            blade.subtitle = 'orders.blades.shipment-detail.subtitle';
        }

        blade.currentStore = _.findWhere(blade.parentBlade.stores, { id: blade.customerOrder.storeId });
        blade.realOperationsCollection = blade.customerOrder.shipments;

        settings.getValues({ id: 'Shipment.Status' }, translateBladeStatuses);
        blade.openStatusSettingManagement = function () {
            var newBlade = new DictionarySettingDetailBlade('Shipment.Status');
            newBlade.parentRefresh = translateBladeStatuses;
            bladeNavigationService.showBlade(newBlade, blade);
        };

        function translateBladeStatuses(data) {
            blade.statuses = statusTranslationService.translateStatuses(data, 'shipment');
        }

        // datepicker
        $scope.datepickers = {}
        $scope.open = function ($event, which) {
            $event.preventDefault();
            $event.stopPropagation();
            $scope.datepickers[which] = true;
        };

        //load pickup date
        //blade.pickupDate = blade.parentBlade.pickupDate;
        //alert(blade.pickupDate);
        //alert(blade.parentBlade.employees);
        console.log('shipment-detail.js');
        console.log(blade);

        blade.toolbarCommands.push({
            name: 'orders.blades.shipment-detail.labels.shipping-label',
            icon: 'fa fa-download',
            //index: 5,
            executeMethod: function (blade) {
                $window.open('api/order/customerOrders/shippingLabel/' + blade.customerOrder.number, '_blank');
                
            },
            canExecuteMethod: function () {
                return true;
            }
        });

        blade.toolbarCommands.push({
            name: 'orders.blades.shipment-detail.labels.parcel-tracking',
            icon: 'fa fa-truck',
            //index: 5,
            executeMethod: function (blade) {
                //RSIT000593376
                var labelUrl = 'https://virto.aftership.com/' + blade.customerOrder.shipments[0].trackingNumber;
                //alert("labelUrl: " + labelUrl);
                //alert($window);
                $window.open(labelUrl, '_blank');

            },
            canExecuteMethod: function () {
                return true;
            }
        });

        // load employees
        blade.employees = blade.parentBlade.employees;

        blade.fulfillmentCenters = order_res_fulfilmentCenters.query();
        blade.openFulfillmentCentersList = function () {
            var newBlade = {
                id: 'fulfillmentCenterList',
                controller: 'virtoCommerce.coreModule.fulfillment.fulfillmentListController',
                template: 'Modules/$(VirtoCommerce.Core)/Scripts/fulfillment/blades/fulfillment-center-list.tpl.html'
            };
            bladeNavigationService.showBlade(newBlade, blade);
        };

        blade.customInitialize = function () {
            blade.isLocked = blade.currentEntity.status == 'Send' || blade.currentEntity.isCancelled;
        };

        blade.updateRecalculationFlag = function () {
            blade.isTotalsRecalculationNeeded = blade.origEntity.price != blade.currentEntity.price || blade.origEntity.priceWithTax != blade.currentEntity.priceWithTax;
        }
    }]);
