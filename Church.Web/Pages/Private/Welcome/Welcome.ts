import Page = require("Scripts/Common/Page");

Page.addController("welcome", ["$scope", "api", function ($scope: Page.IControllerScope, api: Page.IApi): any {
    Page.setTitle("Welcome to Church");
    $scope.data = {
        Id: "Burundi",
        Requests: []
    };
    return api.get("/prayer/needs/Burundi").success((data: any): any => {
        $scope.data.Requests = data;
        return data;
    });
}]);
