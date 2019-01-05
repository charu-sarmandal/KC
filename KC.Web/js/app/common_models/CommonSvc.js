(function () {
    window.app.factory('commonSvc', commonSvc);

    commonSvc.$inject = ['$http'];
    function commonSvc($http) {

        var type = "";
        var svc = {
            add: add,
            update: update,
            delete: deleteItem,
            setType: setType
        };

        return svc;

        function setType(_type) {
            type = _type;
        }


        function add(newItem) {
            return $http.post('/' + type + '/Add', newItem)
                .success(function (item) {
                    console.log("NewItem", item);                    
                });
        }

        function update(existingLabel, updatedLabel) {
            return $http.post('/' + type + '/Update', updatedLabel)
                .success(function (label) {
                    angular.extend(existingLabel, label);
                });
        }

        function deleteItem(item) {
            return $http.post('/' + type + '/Delete', item)
                .success(function (label) {
                    //angular.extend(existingLabel, label);
                });
        }
    }
})();


    