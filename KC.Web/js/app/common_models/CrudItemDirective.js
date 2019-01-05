(function () {
    "use strict";

    window.app.directive('menu', menu);

    function menu() {
        return {  
            replace: true,
            templateUrl: '/js/app/common_models/page-templates/menu.html',
        }
    }
})();



(function () {
    "use strict";

    window.app.directive('header', header);

    function header() {
        return {
            replace: true,
            templateUrl: '/js/app/common_models/page-templates/header.html',
        }
    }
})();


(function () {
    "use strict";

    window.app.directive('breadcrumb', breadcrumb);

    function breadcrumb() {
        return {
            replace: true,
            templateUrl: '/js/app/common_models/page-templates/breadcrumb.html',
        }
    }
})();


(function () {
    "use strict";

    window.app.directive('crudItem', crudItem);

    function crudItem() {
        return {            
            controller: controller,
            controllerAs: 'vm',
            templateUrl: '/js/app/common_models/templates/crud-item-base.html',
            //templateUrl: function (elem, attrs) {
            //    var type = attrs.attrtype;
            //    console.log("attrs.type", type, '/js/app/common_models/templates/' + type + '.html');
            //    return '/js/app/common_models/templates/' + type + '.html';
            //}
        }
    }

    controller.$inject = ['$scope', 'commonSvc', '$state','toaster'];
    function controller($scope, commonSvc, $state, toaster) {
        var vm = this;

        vm.isNew = true;
        vm.saving = false;
        
        vm.type = $state.current.params.parent;
        
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
                    toaster.success({ title: "Edit", body: "Item updated sucessfully" });
                    
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
                    toaster.success({ title: "Insert", body: "Item added sucessfully" });
                    vm.item = {};
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