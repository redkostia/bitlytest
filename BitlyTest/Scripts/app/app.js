console.log('app.js');
var BitlyApp = angular.module("BitlyApp", ['ngRoute']);

BitlyApp.config(["$routeProvider", function ($routeProvider) {
	$routeProvider
		.when("/empty", {
			template: "/content/views/addLink.html",
			controller: "AddLinkController"
		})
		.when("/", {
			templateUrl: "/content/views/addLink.html",
			controller: "AddLinkController"
		})
		.when("/list", {
			templateUrl: "/content/views/listLink.html",
			controller: "ListLinkController"
		});

	//$routeProvider.otherwise({ redirectTo: '/add' });
}]);

