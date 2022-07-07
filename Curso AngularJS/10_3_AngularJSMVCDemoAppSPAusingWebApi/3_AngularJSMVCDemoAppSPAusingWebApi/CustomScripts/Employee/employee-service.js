mainApp.factory('employeeService', function ($http, $q) {
    var factory = {}
    factory.get = function () {
        var deferred = $q.defer();
        $http.get("/api/Employees")
            .success(deferred.resolve)
            .error(deferred.reject);
        return deferred.promise;
    }
    factory.add = function (emp) {
        var deferred = $q.defer();
        $http.post("/api/Employees", emp)
            .success(deferred.resolve)
            .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }
    return factory;
});