(function() {
	'use strict';

    //window.app = angular.module('ShpKart', ['ngAnimate', 'ui.bootstrap', 'ui.grid']);
    window.app = angular.module('KC', ['ngAnimate', 'ui.bootstrap', 'ui.grid',
        'ui.router', 'ngFileUpload', 'ngTable', 'toaster','ngPatternRestrict']);
    
    window.app.config(function ($stateProvider, $urlRouterProvider) {
        console.log("Hi Sandeep");
        $urlRouterProvider.otherwise("/user/list");
        $stateProvider
            .state("home", { url: "/home",params: {parent: 'Home', child: null    }, templateUrl: "/js/app/shared_templates/home.html" })
            .state("user", { url: "/user", templateUrl: "/js/app/shared_templates/home.html" })
            .state("userlist", { url: "/user/list", params: { parent: 'User', child: 'UserList' }, templateUrl: "/js/app/shared_templates/home.html" })
            .state("useradd", { url: "/user/add", params: { parent: 'User', child: 'Add User' }, templateUrl: "/js/app/shared_templates/admin.tmp.html" })

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