BitlyApp.controller('AddLinkController', ['ValuesService', function (ValuesService) {
	var vm = this;
	//
	vm.message = "Add link controller executes";
	vm.isLoading = false;
	vm.originalUrl = '';
	vm.originalSavedUrl = '';
	vm.shortUrl = '';
	vm.status = '';
	vm.localUrl = window.location.origin;
	vm.isFormInValid = function () {
		return vm.addDeviceForm.$invalid && vm.addDeviceForm.$dirty;
	};

	vm.saveDevice = function() {
		if (vm.addDeviceForm.$invalid) {
			vm.addDeviceForm.$dirty = true;
			return;
		}

		vm.isLoading = true;
		vm.status = '';
		ValuesService.shrinkUrl(vm.originalUrl)
			.success(function(data) {
				vm.originalSavedUrl = vm.originalUrl;
				vm.shortUrl = vm.localUrl + '/' + data;
				vm.isLoading = false;
				console.log(data);
			})
			.error(function(error) {
				vm.status = 'Ошибка при сохранении: ' + error.ExceptionMessage;
				vm.isLoading = false;
				console.log(vm.status);
			});
	};
}]);