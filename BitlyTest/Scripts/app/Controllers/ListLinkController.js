BitlyApp.controller('ListLinkController', ['ValuesService', function (ValuesService) {
	var vm = this;
	vm.localUrl = window.location.origin;

	function getLinks() {
		ValuesService.getLinks()
            .success(function (data) {
            	vm.links = data;
            })
            .error(function (error) {
            	vm.status = 'Unable to load customer data: ' + error.message;
            });
	}
	vm.getUrl = function (shortUrl) {
		return vm.localUrl + '/' + shortUrl;
	}
	getLinks();
}]);