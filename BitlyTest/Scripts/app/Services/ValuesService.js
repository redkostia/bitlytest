BitlyApp.factory('ValuesService', [
	'$http', function($http) {
		var ValuesService = {};
		ValuesService.getLinks = function() {
			return $http.get('/api/values');
		};
		ValuesService.shrinkUrl = function (originalUrl) {
			return $http.post('/api/values', JSON.stringify(originalUrl));
		};
	return ValuesService;
}]);