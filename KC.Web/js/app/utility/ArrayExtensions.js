(function() {
	'use strict';

	Object.defineProperty(Array.prototype, 'count', {
		get: function () { return this.length; }
	});

	if (Array.prototype.addRange) return;

	Array.prototype.addRange = function (target) {
		this.push.apply(this, target);
	};

})();


angular.module('myApp', []).directive('hero', function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: { name: '@' },
        template: '<div>' +
            '<div>{{name}}</div><br>' +
            '<div ng-transclude></div>' +
            '</div>'
    };
});



