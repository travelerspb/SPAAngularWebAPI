angular.module("jogApp")
    .controller("workoutsListCtrl", function ($scope) {
    
    $scope.operation = null;
    $scope.operationName = "";

    $scope.showEdit = function() {
        return $scope.operation;
    };

    $scope.createWorkout = function () {
        $scope.operation = null;
        $scope.operation = {date: new Date()};
        $scope.operationName = "Create entry";
    };

    $scope.applyWorkout = function () {
        var item = $scope.operation;
        if (angular.isUndefined(item.id)) {
            new $scope.workoutsResource(item).$create().then(function (newItem) {
                $scope.workouts.push(newItem);
                $scope.operation = null;
            });
        } else {
            item.date = new Date(item.date);
            item.$save();
            $scope.operation = null;
        };
    }

    $scope.deleteWorkout = function (item) {
        item.$delete().then(function () {
            $scope.workouts.splice($scope.workouts.indexOf(item), 1);
        });
    }

    $scope.editWorkout = function(item) {
        $scope.operation = item;
        $scope.operationName = "Edit entry";
    };

    $scope.cancelEdit = function() {
        $scope.operation = null;
    }

    $scope.getButtonName = function() {
        return $scope.operationName.split(" ")[0];
    };

    $scope.betweenDates = function (item) {
        if ($scope.model.dateFrom == null && $scope.model.dateTo == null)
            return item;
        var date = moment(item.date);
        var from = moment($scope.model.dateFrom).isValid() ? moment($scope.model.dateFrom) : moment("2010-01-01");
        var to = moment($scope.model.dateTo).isValid() ? moment($scope.model.dateTo) : moment();
        return date.isBetween(from, to.add(1, "d"), "d");
    };

    $scope.workouts = $scope.workoutsResource.query();

});