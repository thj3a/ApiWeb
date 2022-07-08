//myApp.controller('cityController', ['$scope', 'cityService', function ($scope, cityService) {
//    $scope.cities = cityService.getCities();

myApp.controller('citiesController', ['$scope', 'citiesService', function ($scope, citiesService) {

    $scope.errors = [];
    $scope.generalError = ""

    $scope.get = function () {
        citiesService.get().then(
            function (data) {
                $scope.cities = data;
            },
            function (msg) {
                if (msg.constructor.toString().indexOf("Array") > -1)
                    $scope.errors = msg;
                else if (typeof msg == "object")
                    $scope.generalError = msg.exceptionMessage;
            }
        );
    }

    $scope.add = function (city) {
        if (city == null) {
            $scope.generalError = "Please enter valid data";
            return;
        }

        var promise = citiesService.add(city);
        promise.then(
            function (cities) {
                $scope.cities = cities
                $scope.generalError = "";
                $scope.errors = [];
            },
            function (msg) {
                if (msg.constructor.toString().indexOf("Array") > -1)
                    $scope.errors = msg
                else if (typeof msg == "object")
                    $scope.generalError = msg.exceptionMessage;
            }
        );
    };

    $scope.edit = function (id) {
        var promise = citiesService.edit(id);
        promise.then(function (city) {
            $scope.city = city
        })
    }

    $scope.delete = function (id) {
        var promise = citiesService.delete(id);
        promise.then(function (cities) {
            $scope.cities = cities
            $scope.generalError = "";
            $scope.errors = [];
            alert('Record deleted successfully');
        })
    }

    $scope.update = function (city) {
        if (city == null) {
            $scope.generalError = "Please enter valid data";
            return;
        }
        city.state = null
        city.country = null
        var promise = employeeService.update(city);
        promise.then(
            function (cities) {
                $scope.cities = cities
                $scope.generalError = "";
                $scope.errors = [];
                alert('Record Updated successfully');
            },
            function (msg) {
                if (msg.constructor.toString().indexOf("Array") > -1)
                    $scope.errors = msg
                else if (typeof msg == "object")
                    $scope.generalError = msg.exceptionMessage;
            }
        );
    };

    //Call get method to intialize collection
    $scope.get();
}])