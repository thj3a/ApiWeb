myApp.controller("citiesController", ['$scope', 'citiesService', function ($scope, citiesService) {
    
    $scope.errors = [];
    $scope.generalError = ""

    $scope.get = function () {
        citiesService.get().then(
            function (cities) {
                $scope.cities = cities
            },
            function (msg) {
                if (msg.constructor.toString().indexOf("Array") > -1)
                    $scope.errors = msg
                else if (typeof msg == "object")
                    $scope.generalError = msg.exceptionMessage;
            }
        );
    }

    $scope.add = function (newCity) {
        if (newCity == null) {
            $scope.generalError = "Please enter valid data";
            return;
        }
        newCity.State = null
        var promise = citiesService.add(newCity);
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
            });
    };

    $scope.edit = function (id) {
        var promise = citiesService.edit(id);
        promise.then(function (city) {
            $scope.newCity = city
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

    $scope.update = function (emp) {
        if (emp == null) {
            $scope.generalError = "Please enter valid data";
            return;
        }
        emp.department = null
        var promise = employeeService.update(emp);
        promise.then(
            function (employees) {
                $scope.employees = employees
                $scope.generalError = "";
                $scope.errors = [];
                alert('Record Updated successfully');
            },
            function (msg) {
                if (msg.constructor.toString().indexOf("Array") > -1)
                    $scope.errors = msg
                else if (typeof msg == "object")
                    $scope.generalError = msg.exceptionMessage;
            });
    };

    //Call get method to intialize employees collection
    $scope.get();
}])