
(function () {

    window.app.directive('ngGrid', ngGrid);
    ngGrid.$inject = ['$state', '$stateParams'];
    function ngGrid($state, $stateParams) {
        return {
            controller: controller,
            controllerAs: 'vm',
            templateUrl: '/js/app/common_models/grid-templates/common.html',
            //templateUrl: function (elem, attrs) {
            //    console.log("$state", $state);
            //    console.log("$state", $stateParams);
            //    console.log("Sandeep");
            //    var tpl = $state.current.name;
            //    tpl = "user";

            //    var type = attrs.attrtype;
            //    console.log("attrs.type", type, '/js/app/common_models/grid-templates/' + tpl + '.html');
            //    return '/js/app/common_models/grid-templates/' + tpl + '.html';
            //}
        }
    }

    controller.$inject = ['$scope', '$http', '$location', '$modal', 'NgTableParams', 'commonSvc', '$timeout', 'toaster', '$state'];
    function controller($scope, $http, $location, $modal, NgTableParams, commonSvc, $timeout, toaster, $state) {
        var vm = this;
        vm.loading = true;
        vm.error = false;

        vm.type = $state.current.params.parent;

        console.log("$state", $state);

        vm.items = [];

        var loc = "/" + vm.type + "/Get";
        console.log("loc", loc);

        vm.getActualTemplateContent = function () {
            return '/js/app/common_models/grid-templates/' + vm.type + '.html'
        };

        vm.add = function () {
            console.log("Add vm.type", vm.type);

            //vm.tableParams._settings.dataset = vm.items;
            //vm.tableParams.reload();
            console.log("vm.tableParams", $scope.tableParams, vm.tableParams);


            var modalInstance = $modal.open({
                //animation:true,
                template: '<crud-item-modal item="item" type="type" attrtype="' + vm.type + '" />',
                scope: angular.extend($scope.$new(true), { item: null, type: vm.type }),
                windowClass: 'animated bounceIn show',
                show: true,
                backdrop: 'static', keyboard: false
            });
            modalInstance.result.then(function (item) {
                vm.items.unshift(item);
                vm.tableParams._settings.dataset = vm.items;
                vm.tableParams.reload();
                toaster.success({ title: "Insert", body: "Item added sucessfully" });

            }, function () {
                console.info('Modal dismissed at: ' + new Date());
            });
        }

        var reload = function (item) {
            console.log("Reload Called", item);
        }

        vm.edit = function (item) {

            console.log("Add vm.type", vm.type);
            console.log("item", item);
            var modalInstance = $modal.open({
                template: '<crud-item-modal item="item" type="type" attrtype="' + vm.type + '" />',
                scope: angular.extend($scope.$new(true), { item: item, type: vm.type }),
                windowClass: 'animated bounceIn show',
                show: true,
                backdrop: 'static', keyboard: false
            });

            modalInstance.result.then(function (result) {
                vm.tableParams._settings.dataset = vm.items;
                vm.tableParams.reload();
                toaster.success({ title: "Edit", body: "Item updated sucessfully" });

                console.log('result: ', result);
            }, function () {
                console.info('Modal dismissed at: ' + new Date());
            });

        }

        var deleteItem = function (item) {
            console.log("Delete Id", item);
            for (var i = 0; i < vm.items.length; i++) {
                if (vm.items[i].id == item.id) {
                    vm.items.splice(i, 1);
                    break;
                }
            }
            vm.tableParams._settings.dataset = vm.items;
            vm.tableParams.reload();

        }
        var confirmDelete = function (item) {
            commonSvc.setType(vm.type);

            vm.saving = true;
            commonSvc.delete(item)
                .success(function () {
                    deleteItem(item);
                    toaster.success({ title: "Delete", body: "Item deleted sucessfully" });
                    //$scope.$parent.$close();
                })
                .error(function (data) {
                    vm.errorMessage = 'There was a problem saving changes to the item: ' + data;
                })
                .finally(function () {
                    vm.saving = false;
                });

        }
        vm.delete = function (item) {
            var message = "Are you sure ?";

            var modalHtml = '<div class="modal-body">' + message + '</div>';
            modalHtml += '<div class="modal-footer"><button class="btn btn-primary" ng-click="$close()">OK</button><button class="btn btn-warning" ng-click="$dismiss()">Cancel</button></div>';

            var modalInstance = $modal.open({
                template: modalHtml,
                windowClass: 'animated bounceIn show',
                show: true,
                backdrop: 'static', keyboard: false
            });

            modalInstance.result.then(function () {
                confirmDelete(item);
            });

        }

        vm.tableParams = new NgTableParams({
            sorting: { id: "desc" }
        },
            {
                dataset: vm.items
            });

        var init = function () {
            $http.post(loc)
                .success(function (data) {
                    console.log("data", data);

                    vm.items = data;
                    vm.tableParams._settings.dataset = vm.items;
                    vm.tableParams.reload();
                    vm.loading = false;
                })
                .error(function (data) {
                    vm.loading = false;
                    vm.error = true;
                });

        }

        window.setTimeout(function () {
            init();
        }, 0);


        vm.export = function () {
            $http({
                url: '/' + vm.type + '/DownloadExcelFile',
                method: "POST",
                //data: json, //this is your json data string
                headers: {
                    'Content-type': 'application/json'
                },
                responseType: 'arraybuffer'
            }).success(function (data, status, headers, config) {
                var blob = new Blob([data], { type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" });
                //var objectUrl = URL.createObjectURL(blob);
                //window.open(objectUrl);

                saveExportFile(blob, vm.type + ".xlsx");
            }).error(function (data, status, headers, config) {
                //upload failed
            });

            //DownloadExcel
        }



        var saveExportFile = function (blob, fileName) {
            if (window.navigator.msSaveOrOpenBlob) { // For IE:
                navigator.msSaveBlob(blob, fileName);
            } else { // For other browsers:
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(blob);
                link.download = fileName;
                link.click();
                window.URL.revokeObjectURL(link.href);
            }
        }

    }

})();
