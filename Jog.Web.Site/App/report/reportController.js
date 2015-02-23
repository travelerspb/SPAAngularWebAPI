angular.module("jogApp")
    .controller("reportCtrl", function($scope) {

        $scope.report = [];

        $scope.getReportData = function () {
            var data = $scope.workoutsResource.query(function() {
                data.sort(function(a, b) {
                    if (a.date > b.date) {
                        return -1;
                    }
                    if (a.date < b.date) {
                        return 1;
                    }
                    return 0;
                });

                var dateTo = moment(data[data.length - 1].date),
                    dateFrom = data[0].date,
                    t = moment(dateFrom),
                    d = t.isoWeekday(),
                    nextSunday = t.add(7 - d, "d"),
                    workerDay = nextSunday.clone();
                
                while (workerDay.isAfter(dateTo)) {
                    var week = data.filter(function(element) {
                        element = moment(element.date);
                        var from = workerDay.clone().add(-8, "d"),
                            to = workerDay.clone().add(1, "d");
                        return element.isBetween(from, to, "d");
                    });

                    if (week.length > 0) {
                        var sumDistance = 0,
                            sumDuration = 0;
                        for (var i = 0; i < week.length; i++) {
                            sumDistance += week[i].distance;
                            sumDuration += week[i].duration;
                        }

                        $scope.report.push({
                            dateFrom: workerDay.format(),
                            dateTo: workerDay.clone().add(-6, "d").format(),
                            avgDistance: Math.round(sumDistance / week.length),
                            avgSpeed: sumDistance / sumDuration
                        });
                    };
                    workerDay.add(-7, "d");
                };
            });
        };

        $scope.getReportData();

        $scope.betweenWeeks = function (item) {
            if ($scope.model.dateFrom == null && $scope.model.dateTo == null)
                return item;
            var dateFrom = new Date(item.dateFrom);
            var dateTo = new Date(item.dateTo);
            return dateFrom <= $scope.model.dateTo && dateTo >= $scope.model.dateFrom;
        };
});