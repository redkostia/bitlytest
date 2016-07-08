BitlyApp.controller('MenuController', ['$location', function(l) {
	var vm = this;
	vm.goToLink = function (path) {
		console.log(path);
		l.path(path);
	}
	
}]);