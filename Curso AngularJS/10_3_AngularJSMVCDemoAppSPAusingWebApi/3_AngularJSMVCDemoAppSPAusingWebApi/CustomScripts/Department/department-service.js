mainApp.factory('departmentService', function ($http, $q) {
    return {
        get: function () {
            var deferred = $q.defer();
            $http.get("/api/Departments").success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});