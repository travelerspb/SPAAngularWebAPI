///<reference path="~/Scripts/jasmine/jasmine.js"/>
///<reference path="~/Scripts/angular.js"/>
///<reference path="~/Scripts/angular-mocks.js"/>
///<reference path="~/Scripts/angular-route.js"/>
///<reference path="~/Scripts/angular-strap.min.js"/>
///<reference path="~/Scripts/angular-strap.tpl.min.js"/>
///<reference path="~/scripts/angular-resource.js"/>
///<reference path="~/scripts/angular-storage.js"/>
///<reference path="~/scripts/angular-jwt.js"/>
///<reference path="~/Scripts/moment.min.js"/>

///<reference path="~/App/app.js"/>
///<reference path="~/App/filters.js"/>
///<reference path="~/App/account/account.js"/>
///<reference path="~/App/workouts/workoutListController.js"/>
///<reference path="~/App/report/reportController.js"/>

describe("Km-m formating Test", function () {
    // Arrange
    var filterInstance;

    beforeEach(module("jogApp.Filters"));

    beforeEach(angular.mock.inject(function ($filter) {
        filterInstance = $filter("metersToKm");
    }));
        
    it("Only meters", function () {
        var result = filterInstance(100);
        expect(result).toEqual("100 m");
    });

    it("Proper kilometers", function () {
        var result = filterInstance(2000);
        expect(result).toEqual("2 km 0 m");
    });
});


describe("Sec-min-h formating Test", function () {
    // Arrange
    var filterInstance;

    beforeEach(module("jogApp.Filters"));

    beforeEach(angular.mock.inject(function ($filter) {
        filterInstance = $filter("secToTime");
    }));
        
    it("Only seconds", function () {
        var result = filterInstance(40);
        expect(result).toEqual("40 s");
    });

    it("Proper minutes and seconds", function () {
        var result = filterInstance(103);
        expect(result).toEqual("1 m 43 s");
    });
});
