mainApp.controller("departmentController", ['$scope', 'departmentService', function ($scope, departmentService) {
    $scope.get = function () {
        var promise = departmentService.get();
        promise.then(function (departments) {
            $scope.departments = departments
        },
            function (msg) {
                $scope.generalError = msg.exceptionMessage;
            })
    };

    $scope.get();
    $scope.errors = [];
    $scope.generalError = ""
    $scope.add = function (dept) {
        if (dept == null) {
            $scope.generalError = "Please enter valid data";
            return;
        }
        var promise = departmentService.add(dept);
        promise.then(
            function (departments) {
                $scope.departments = departments
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
        var promise = departmentService.getDetails(id);
        promise.then(function (departments) {
            $scope.newDept = departments
        })
    }

    $scope.delete = function (id) {
        var promise = departmentService.delete(id);
        promise.then(function (departments) {
            $scope.departments = departments
            $scope.generalError = "";
            $scope.errors = [];
            alert('Record deleted successfully');
        })
    }

    $scope.update = function (dept) {
        if (dept == null) {
            $scope.generalError = "Please enter valid data";
            return;
        }
        var promise = departmentService.update(dept);
        promise.then(
            function (departments) {
                $scope.departments = departments
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
}]);