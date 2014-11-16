import Page = require("Scripts/Common/Page");

Page.addController("prayerNeeds", ["$scope", "$sce", function ($scope: Page.IControllerScope, $sce: ng.ISCEService): void {
    $scope.data = {
        Url: $sce.trustAsResourceUrl("https://www.wvi.org/burundi/article/hope-orphan-girl")
    };
}]);
