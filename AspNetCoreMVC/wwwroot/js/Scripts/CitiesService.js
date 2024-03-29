﻿myApp.factory('citiesService', ['$http', '$q', function ($http, $q) {
    var factory = {}
    factory.get = function () {
        var deferred = $q.defer();
        $http.get("api/Cities")
            .success(deferred.resolve)
            .error(deferred.reject);
        return deferred.promise;
    }

    factory.add = function (newCity) {
        var deferred = $q.defer();
        $http.post(, newCity)
            .success(function (data, code, headers, config) { deferred.resolve(data); })
            .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }

    //To get details of a particular employee to be edited.
    factory.edit = function (id) {
        var deferred = $q.defer();
        $http.get("api/citiesController/" + id).success(function (data, code, headers, config) {
            deferred.resolve(data);
        })
            .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }

    //To save changes to the edited employee
    factory.update = function (city) {
        var deferred = $q.defer();
        $http.put("api/Cities/" + newCity.Id, city)
            .success(function (data, code, headers, config) { deferred.resolve(data); })
            .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }

    factory.delete = function (id) {
        var deferred = $q.defer();
        $http.delete("api/Cities/" + id).success(function (data, code, headers, config) {
            deferred.resolve(data);
        })
            .error(function (msg, code, headers, congig) { deferred.reject(msg); });
        return deferred.promise;
    }
    return factory;
}])