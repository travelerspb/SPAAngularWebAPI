angular.module("jog.account", [
    "angular-storage"
])
.controller("AccountCtrl", function ($scope, $http, $location, store, baseUrl) {

     var checkAccount = function (data) {
        var error = "";
        for (var i in data.modelState) {
            error += data.modelState[i] + "\n";
        }
        $scope.model.error = error;
    };

    $scope.user = { grant_type:"password" };
    $scope.newUser = {};

    $scope.isLogin = function () {
         return store.get("key");
     };

     $scope.Logout = function() {
         store.remove("key");
     }

     $scope.Login = function () {
        // Transform from obj to proper string (no use jQuery)
        var fixedData = [];
        for(var p in $scope.user)
                 fixedData.push(encodeURIComponent(p) + "=" + encodeURIComponent($scope.user[p]));

        $http.post(baseUrl + "Token",
            fixedData.join("&"),
            { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
            .success(function(data) {
                store.set("key", data.access_token);
                $location.path("/workouts");
                $scope.model.error = null;
            })
            .error(function(data) {
            $scope.model.error = data.error_description;
        });
     };

    $scope.signUp = function() {
        $http.post("http://windows:3126/api/account/register", $scope.newUser)
            .success(function() {
                $scope.model.error = "New user created. You can use your credentials to login now.";
            })
            .error(checkAccount);
    };
});