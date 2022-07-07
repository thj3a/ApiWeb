mainApp.controller("employeeController", ['$scope', 'employeeService', function ($scope, employeeService) {

    $scope.get = function () {
        employeeService.get().then(function (employees) {
            $scope.employees = employees
        })
    }
    $scope.errors = [];
    $scope.generalError = ""
    $scope.add = function (emp) {
        if (emp == null || emp.selectedDepartment == null)
        {
            $scope.generalError = "Please enter valid data";
            return;
        }
        emp.deptId = emp.selectedDepartment.deptId;
        var promise = employeeService.add(emp);
        promise.then(
            function (employees)
            {
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
    $scope.selectedDepartment = "DA"
    $scope.get();
}]);