(function () {
    "use strict";

    window.app.directive('crudItemModal', crudItemModal);

    function crudItemModal() {
        return {
            scope: {
                item: "=",               
                type: "=",                
            },
            controller: controller,
            controllerAs: 'vm',
            templateUrl: '/js/app/common_models/templates/crud-modal-base.html',
            //templateUrl: function (elem, attrs) {
            //    var type = attrs.attrtype;
            //    console.log("attrs.type", type, '/js/app/common_models/templates/' + type + '.html');
            //    return '/js/app/common_models/templates/' + type + '.html';
            //}
        }
    }

    controller.$inject = ['$scope', 'commonSvc'];
    function controller($scope, commonSvc) {
        var vm = this;

        vm.isNew = true;
        vm.saving = false;
        
        vm.type = $scope.type;
        
        commonSvc.setType(vm.type);
        console.log("vm.type", vm.type, $scope.item);
        vm.item = {};
        if ($scope.item) {
            vm.isNew = false;
            vm.item = angular.copy($scope.item);
        }
        vm.errorMessage = null;

        vm.getActualTemplateContent = function () {
            return '/js/app/common_models/templates/' + vm.type + '.html'
        };

        vm.delete = function () {
            if (window.confirm("Are you sure want to delete?")) {
                vm.saving = true;
                commonSvc.delete($scope.item, vm.item)
                    .success(function () {
                        deleteItem();
                        $scope.$parent.$close();
                    })
                    .error(function (data) {
                        vm.errorMessage = 'There was a problem saving changes to the item: ' + data;
                    })
                    .finally(function () {
                        vm.saving = false;
                    });
            }
        }

        vm.save = function () {            
            if (vm.isNew) {
                add();
            }
            else {
                update();
            }
        }
               

        function update() {
            vm.saving = true;
            commonSvc.update($scope.item, vm.item)
                .success(function (data) { 
                    console.log("service data", data);
                    
                    $scope.$parent.$close(data);
                })
                .error(function (data) {
                    vm.errorMessage = 'There was a problem saving changes to the item: ' + data;
                })
                .finally(function () {
                    vm.saving = false;
                });
        }

        function add() {
            vm.saving = true;
            commonSvc.add(vm.item)
                .success(function (data) {
                    console.log("service data add", data);

                    //$scope.$parent.reload();
                    $scope.$parent.$close(data);
                })
                .error(function (data) {
                    vm.errorMessage = 'There was a problem adding the label: ' + data;
                })
                .finally(function () {
                    vm.saving = false;
                });
        }
    }
})();