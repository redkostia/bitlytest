var BitlyApp = angular.module("BitlyApp", ['ngRoute']);

BitlyApp.config(["$routeProvider", function ($routeProvider) {
	$routeProvider
		.when("/", {
			templateUrl: "/content/views/addLink.html",
			controller: "AddLinkController",
			controllerAs: 'vm'
		})
		.when("/list", {
			templateUrl: "/content/views/listLink.html",
			controller: "ListLinkController",
			controllerAs: 'vm'
		});

	//$routeProvider.otherwise({ redirectTo: '/add' });
}]);

