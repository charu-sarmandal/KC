(function () {

    window.app.directive('mvcGrid', mvcGrid);
    function mvcGrid() {
        return {
            scope: {
                file: '='
                //columns: '@?'
            },
            templateUrl: '/js/app/shared_templates/mvcGrid.tmp.html',
            controllerAs: 'vm',
            controller: controller
        }
    }

    controller.$inject = ['$scope', '$http', '$location', '$modal'];
    function controller($scope, $http, $location, $modal) {
        var vm = this;
        vm.type = ($scope.file && $scope.file.type) ? $scope.file.type : $location.path().replace("/", "");
        console.log("vm.type", vm.type);
        vm.items = [];

        var loc = "/" + vm.type + "/GetGridModel";
        if ($scope.file && $scope.file.fileName) {
            console.log("$scope.file", $scope.file.fileName);
            loc = "/" + vm.type + '/GetReportGridModel?fileName=' + $scope.file.fileName + '&type=' + $scope.file.type;
            console.log("loc", loc);
        }
        console.log("loc", loc);


        var gridInitialize = function () {
            vm.loading = true;
            vm.gridOptions = {
                enableHorizontalScrollbar: 0,
                rowTemplate: rowTemplate(),
                enableRowSelection: true
            }
            function rowTemplate() {    //custom rowtemplate to enable double click and right click menu options
                return '<div ng-dblclick="grid.appScope.rowDblClick(row)"  ng-repeat="(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name" class="ui-grid-cell" ng-class="{ \'ui-grid-row-header-cell\': col.isRowHeader }"  ui-grid-cell  ></div>'
            }

            $scope.rowDblClick = function (row) {
                console.log("row", row);
                view(row.entity);
            };

            $http.post(loc)
                .success(function (data) {
                    console.log("data", data);
                    vm.gridDataUrl = data.gridOptions.dataUrl;
                    vm.title = data.gridOptions.title;
                    vm.gridOptions.columnDefs = data.columns;
                    vm.items = data.data;
                    vm.gridOptions.data = vm.items;
                    vm.loading = false;
                });

        }
        vm.approve = function () {
            var fileForm = {};
            fileForm.id = $scope.file.id;
            fileForm.reviewDescription = "approve by Sandeep";
            fileForm.reviewStatus = "approve";

            return $http.post('/' + vm.type + '/UpdateUploadFile', fileForm)
                .success(function (item) {
                    console.log("NewItem", item);
                    //items.unshift(item);
                });
        }


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

                saveExportFile(blob, vm.type+".xlsx");
            }).error(function (data, status, headers, config) {
                //upload failed
            });

            //DownloadExcel
        }

        

        var saveExportFile = function(blob, fileName) {
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

        vm.add = function () {
            console.log("Add vm.type", vm.type);
            $modal.open({
                template: '<crud-item item="item" items="items" type="type" attrtype="' + vm.type + '" />',
                scope: angular.extend($scope.$new(true), { items: vm.items, item: null, type: vm.type })
            });
        }

        vm.uploadFile = function () {
            var _file = null;// "F:\\Applications\\Kart\\ShpKart\\ShpKart.Web\\ImportFiles\\Customer.xlsx";
            $modal.open({
                template: '<mvc-grid-file-upload type="type" file="file" />',
                scope: angular.extend($scope.$new(true), { type: vm.type, file: _file })
            });
        }
        vm.filter = {};
        vm.search = function () {
            var f = vm.filter;
            console.log("vm.filter", vm.filter);
            return $http.post('/' + vm.type + '/GetData', vm.filter)
                .success(function (items) {
                    console.log("NewItem11", items);
                    //items.unshift(item);
                    vm.items = items;
                    vm.gridOptions.data = vm.items;
                });
        }

        function view(_item) {
            $modal.open({
                template: '<crud-item item="item" items="items" type="type"  attrtype="' + vm.type + '" />',
                scope: angular.extend($scope.$new(true), { item: _item, items: vm.items, type: vm.type })
            });
        }

        var init = function () {
            gridInitialize();
        };

        init();
    }

})();
