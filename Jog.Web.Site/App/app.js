angular.module("jogApp",
    [
        "ngRoute",
        "jog.account",
        "angular-jwt",
        "angular-storage",
        "ngResource",
        "mgcrea.ngStrap",
        "jogApp.Filters"
    ])
    .constant("baseUrl", "http://windows:3126/api/")
    .config(function ($routeProvider, jwtInterceptorProvider, $httpProvider) {

        $routeProvider.when("/report", {
            templateUrl: "app/report/report.html"
        });

        $routeProvider.when("/workouts", {
            templateUrl: "app/workouts/workouts.html"
        });

        $routeProvider.when("/account", {
            templateUrl: "app/account/account.html"
        });

        $routeProvider.otherwise({
            redirectTo: "/account"
        });

        jwtInterceptorProvider.tokenGetter = function(store) {
            return store.get("key");
        }
        $httpProvider.interceptors.push("jwtInterceptor");

        $httpProvider.interceptors.push(function ($q) {
            return {
                'response': function (response) {
                    return response;
                },
                'responseError': function (rejection) {
                    var status = rejection.status;
                    if (status == 401) {
                        window.location = "#/account";
                        return;
                    }
                    return $q.reject(rejection);
                }
            };
        });
});
   

angular.module("jogApp").controller("AppCtrl", function ($scope, $http, $resource, store, baseUrl) {

    $scope.model = {dateFrom:null, dateTo: new Date(), error: null};

    $scope.workouts = {};

    $scope.showError = function () {
        return $scope.model.error != null;
    }

    $scope.workoutsResource = $resource(baseUrl + "workouts/" + ":id", { id: "@id" },
    { create: { method: "POST" }, save: { method: "PUT" } });

});
