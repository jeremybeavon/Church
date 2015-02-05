import Page = require("Scripts/Common/Page");

Page.addController("prayerNeeds", ["$scope", function ($scope: Page.IControllerScope): void {
    $scope.data = {
        //Url: $sce.trustAsResourceUrl("https://www.wvi.org/burundi/article/hope-orphan-girl")
    };
}]);
