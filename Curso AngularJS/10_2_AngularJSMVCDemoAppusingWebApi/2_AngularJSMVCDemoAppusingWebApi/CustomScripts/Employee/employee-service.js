mainApp.factory('employeeService', function ($http, $q) {
    var factory = {}
    factory.get = function () {
        var deferred = $q.defer();
        $http.get("/api/Employees")
            .success(deferred.resolve)
            .error(deferred.reject);
        return deferred.promise;
    }

    factory.add = function (newEmp) {
        var deferred = $q.defer();
        $http.post("/api/Employees", newEmp)
            .success(function (data, code, headers, config) { deferred.resolve(data); })
            .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }

    //To get details of a particular employee to be edited.
    factory.edit = function (id) {
        var deferred = $q.defer();
        $http.get("/api/Employees/" + id).success(function (data, code, headers, config) {
            deferred.resolve(data);
        })
        .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }

    //To save changes to the edited employee
    factory.update = function (emp) {
        var deferred = $q.defer();
        $http.put("/api/Employees/"+emp.empId, emp)
            .success(function (data, code, headers, config) { deferred.resolve(data); })
            .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }

    factory.delete = function (id) {
        var deferred = $q.defer();
        $http.delete("/api/Employees/" + id).success(function (data, code, headers, config) {
            deferred.resolve(data);
        })
        .error(function (msg, code, headers, congig) { deferred.reject(msg); });
        return deferred.promise;
    }

    return factory;
});