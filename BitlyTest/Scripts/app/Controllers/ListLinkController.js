BitlyApp.controller('ListLinkController', ['$scope', '$location', 'ValuesService', function (scope, l, ValuesService) {

	scope.localUrl = window.location.origin;

	function getLinks() {
		ValuesService.getLinks()
            .success(function (data) {
            	scope.links = data;
            	console.log(data);
            })
            .error(function (error) {
            	scope.status = 'Unable to load customer data: ' + error.message;
            	console.log(scope.status);
            });
	}
	scope.getUrl = function(shortUrl) {
		return scope.localUrl + '/'+ shortUrl;
	}
	getLinks();
}]);