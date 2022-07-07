mainApp.controller("departmentController", ['$scope', 'departmentService', function ($scope, departmentService) {
    departmentService.get().then(function (departments) {
        $scope.departments = departments
    })
  }
]); 