BitlyApp.controller('AddLinkController', ['$scope', '$location', 'ValuesService', function (scope, l, ValuesService) {
	console.log('add link');
	//
	scope.message = "Add link controller executes";
	scope.isLoading = false;
	scope.originalUrl = '';
	scope.originalSavedUrl = '';
	scope.shortUrl = '';
	scope.status = '';
	scope.localUrl = window.location.origin;
	scope.isFormInValid = function () {
		return scope.addDeviceForm.$invalid && scope.addDeviceForm.$dirty;
	};

	scope.saveDevice = function () {
		if (scope.addDeviceForm.$invalid) {
			scope.addDeviceForm.$dirty = true;
			return;
		}
			
		scope.isLoading = true;
		scope.status = '';
		ValuesService.shrinkUrl(scope.originalUrl)
				.success(function (data) {
					scope.originalSavedUrl = scope.originalUrl;
					scope.shortUrl = scope.localUrl + '/' + data;
					scope.isLoading = false;
					console.log(data);
				})
				.error(function (error) {
					scope.status = 'Ошибка при сохранении: ' + error.ExceptionMessage;
					scope.isLoading = false;
					console.log(scope.status);
				});
		//DeviceService.saveDevice(scope.device, function (err, data) {
		//	helpers.preloader.hide();
		//	if (err) {
		//		console.log("Device controller", err);
		//		return;
		//	}
		//	scope.getDevices();
		//	scope.device = {};
		//});
		
	};
}]);