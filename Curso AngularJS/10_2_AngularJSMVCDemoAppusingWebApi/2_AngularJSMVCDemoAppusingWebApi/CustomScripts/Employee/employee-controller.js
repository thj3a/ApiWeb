mainApp.controller("employeeController", ['$scope', 'employeeService', 'departmentService', function ($scope, employeeService, departmentService) {
    $scope.errors = [];
    $scope.generalError = ""

    $scope.get = function () {
        employeeService.get().then(function (employees) {
            $scope.employees = employees
        })
    }

    $scope.add = function (newEmp) {
        if (newEmp == null) {
            $scope.generalError = "Please enter valid data";
            return;
        }
        newEmp.department = null
        var promise = employeeService.add(newEmp);
        promise.then(
            function (employees) {
                $scope.employees = employees
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
        var promise = employeeService.edit(id);
        promise.then(function (employee) {
            $scope.newEmp = employee
        })
    }

    $scope.delete = function (id) {
        var promise = employeeService.delete(id);
        promise.then(function (employees) {
            $scope.employees = employees
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
}]);