//myApp.service('cityService', ['$http', '$q', function ($http, $q) {
//    this.getCities = function () {
//        return @Html.Raw(Model);
//    }
//    this.getCity = function (id) {
//        return
//    }
//}])


myApp.factory('citiesService', function ($http, $q) {
    
    var factory = {}

    factory.get = function () {
        var deferred = $q.defer();
        $http.get("Home/GetCities")
            .then(
                function (data) {
                deferred.resolve(data);
                },
                function (msg, code) {
                deferred.reject(msg);
                $log.error(msg, code);
                }
            );
        return deferred.promise;
    }

    
    
    factory.add = function (newCity) {
        var deferred = $q.defer();
        $http.post("Home/Post", newCity)
            .then(
                function (data) {
                    deferred.resolve(data);
                },
                function (msg, code) {
                    deferred.reject(msg);
                    $log.error(msg, code);
                }
            );
        return deferred.promise;
    }

    //To get details of a particular employee to be edited.
    factory.edit = function (id) {
        var deferred = $q.defer();
        $http.get("Home/GetCity/" + id)
        //    .success(function (data, code, headers, config) {
        //    deferred.resolve(data);
        //})
        //    .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }

    //To save changes to the edited employee
    factory.update = function (city) {
        var deferred = $q.defer();
        $http.put("Home/GetCities" + newCity.Id, city)
        //    .success(function (data, code, headers, config) { deferred.resolve(data); })
        //    .error(function (msg, code, headers, config) { deferred.reject(msg); });
        return deferred.promise;
    }

    factory.delete = function (id) {
        var deferred = $q.defer();
        $http.delete("Cities/" + id)
        //    .success(function (data, code, headers, config) {
        //    deferred.resolve(data);
        //})
        //    .error(function (msg, code, headers, congig) { deferred.reject(msg); });
        return deferred.promise;
    }
    return factory;
})