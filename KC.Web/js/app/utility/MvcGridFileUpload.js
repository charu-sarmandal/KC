(function () {

    window.app.directive('mvcGridFileUpload', mvcGridFileUpload);
    function mvcGridFileUpload() {
		return {
			scope: {
                type: '=',
                file: '='
			},
            templateUrl: '/js/app/shared_templates/mvcGridFileUpload.tmp.html',
			controllerAs: 'vm',
			controller: controller
		}
	}

    controller.$inject = ['$scope', '$http', '$location', '$modal', 'Upload', '$timeout'];
    function controller($scope, $http, $location, $modal,Upload, $timeout) {
        var vm = this;
        vm.file = $scope.file;
        vm.log = '';
        vm.type = $scope.type;
        console.log("ptah", '/' + vm.type + '/FileUpload');
        
        vm.upload = function () {
            var file = vm.importFile;
            console.log("file", vm.importFile);
            
            Upload.upload({
                url: '/' + vm.type+'/FileUpload',
                file: file
            }).progress(function (evt) {
                var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                vm.log = 'progress: ' + progressPercentage + '% ' +
                    evt.config.file.name + '\n' + vm.log;
                console.log("log", vm.log)
            }).success(function (data) {
                vm.file = data;
                console.log("vm.file", vm.file);
            });
        };

        
    }







})();


(function () {
    window.app.directive('fileModel', ['$parse', function ($parse) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                var model = $parse(attrs.fileModel);
                var modelSetter = model.assign; 
                console.log("modelSetter", modelSetter);
                element.bind('change', function () {                    
                    scope.$apply(function () {
                        modelSetter(scope, element[0].files[0]);
                    });
                });
            }
        };
    }]);
   
})();
