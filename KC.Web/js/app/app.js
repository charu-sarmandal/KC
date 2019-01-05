(function() {
	'use strict';

    //window.app = angular.module('ShpKart', ['ngAnimate', 'ui.bootstrap', 'ui.grid']);
    window.app = angular.module('KC', ['ngAnimate', 'ui.bootstrap', 'ui.grid',
        'ui.router', 'ngFileUpload', 'ngTable', 'toaster','ngPatternRestrict']);
    
    window.app.config(function ($stateProvider, $urlRouterProvider) {
        console.log("Hi Sandeep");
        $urlRouterProvider.otherwise("/department/list");
        $stateProvider
            .state("home", { url: "/home",params: {parent: 'Home', child: null    }, templateUrl: "/js/app/shared_templates/home.html" })
            .state("user", { url: "/user", templateUrl: "/js/app/shared_templates/home.html" })
            .state("userlist", { url: "/user/list", params: { parent: 'User', child: 'UserList' }, templateUrl: "/js/app/shared_templates/home.html" })
            .state("useradd", { url: "/user/add", params: { parent: 'User', child: 'Add User' }, templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            
            .state("departmentlist", { url: "/department/list", params: { parent: 'Department', child: 'DepartmentList' }, templateUrl: "/js/app/shared_templates/home.html" })
            .state("departmantadd", { url: "/department/add", params: { parent: 'Department', child: 'Add Department' }, templateUrl: "/js/app/shared_templates/admin.tmp.html" })

            .state("modulelist", { url: "/module/list", params: { parent: 'Module', child: 'ModuleList' }, templateUrl: "/js/app/shared_templates/home.html" })
            .state("moduleadd", { url: "/module/add", params: { parent: 'Module', child: 'Add Module' }, templateUrl: "/js/app/shared_templates/admin.tmp.html" })

            .state("rolelist", { url: "/role/list", params: { parent: 'Role', child: 'RoleList' }, templateUrl: "/js/app/shared_templates/home.html" })
            .state("roleadd", { url: "/role/add", params: { parent: 'Role', child: 'Add Role' }, templateUrl: "/js/app/shared_templates/admin.tmp.html" })

            .state("taxratelist", { url: "/taxrate/list", params: { parent: 'Taxrate', child: 'TaxrateList' }, templateUrl: "/js/app/shared_templates/home.html" })
            .state("taxrateadd", { url: "/taxrate/add", params: { parent: 'Taxrate', child: 'Add Taxrate' }, templateUrl: "/js/app/shared_templates/admin.tmp.html" })

            .state("holidaylist", { url: "/holiday/list", params: { parent: 'Holiday', child: 'HolidayList' }, templateUrl: "/js/app/shared_templates/home.html" })
            .state("holidayadd", { url: "/holiday/add", params: { parent: 'Holiday', child: 'Add Holiday' }, templateUrl: "/js/app/shared_templates/admin.tmp.html" })

            .state("materiallist", { url: "/material/list", params: { parent: 'Material', child: 'MaterialList' }, templateUrl: "/js/app/shared_templates/home.html" })
            .state("materialadd", { url: "/material/add", params: { parent: 'Material', child: 'Add Material' }, templateUrl: "/js/app/shared_templates/admin.tmp.html" })


            .state("label", { url: "/label", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("sublabel", { url: "/sublabel", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("tag", { url: "/tag", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            
            .state("report", { url: "/report", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("BuyInventory", { url: "/BuyInventory", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("Dashboard", { url: "/Dashboard", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("Menu", { url: "/Menu", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("Product", { url: "/Product", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("ProductDetail", { url: "/ProductDetail", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("SellInventory", { url: "/SellInventory", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("HtmlTemplate", { url: "/HtmlTemplate", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("ProductLabelMapper", { url: "/ProductLabelMapper", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            .state("ScheduleProductLabelMapper", { url: "/ScheduleProductLabelMapper", templateUrl: "/js/app/shared_templates/admin.tmp.html" })
            ;
    });

})();