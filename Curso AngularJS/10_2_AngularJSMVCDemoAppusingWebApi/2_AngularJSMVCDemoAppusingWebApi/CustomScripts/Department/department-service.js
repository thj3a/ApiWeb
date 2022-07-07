mainApp.factory('departmentService', function ($http, $q) {
    var factory = {}
    factory.get = function () {
            var deferred = $q.defer();
            $http.get("/api/Departments").success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
    }

    factory.getDetails = function (id) {
        var deferred = $q.defer();
        $http.get("/api/Departments/" + id).success(function (data, code, headers, config) {
            deferred.resolve(data);
        })
        .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }

    factory.getDept = function (id) {
        var deferred = $q.defer();
        $http.get("/api/Departments/" + id).success(deferred.resolve).error(deferred.reject);
        return deferred.promise;
    }
    
    factory.add = function (dept) {
            var deferred = $q.defer();
        $http.post("/api/Departments", dept)
                .success(function (data, code, headers, config) { deferred.resolve(data); })
                .error(function (msg, code, headers, config) { deferred.reject(msg); });
            return deferred.promise;
    }
    
    factory.delete = function (id) {
        var deferred = $q.defer();
        $http.delete("/api/Departments/" + id).success(function (data, code, headers, config) {
            deferred.resolve(data);
        })
        .error(function (msg, code, headers, congig) { deferred.reject(msg); });
        return deferred.promise;
    }

    factory.update = function (dept) {
        var deferred = $q.defer();
        $http.put("/api/Departments/" + dept.deptId, dept)
            .success(function (data, code, headers, config) { deferred.resolve(data); })
            .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }
    return factory;
});