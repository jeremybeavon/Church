import Page = require("Scripts/Common/Page");

Page.addController("publicWelcome", ["$scope", function ($scope: Page.IControllerScope): void {
    Page.setTitle("Welcome to Church");
    $scope.translations = {
        welcome:
            "You are deeply loved by God.  \n" +
            "Love is patient.  \n" +
            "Love is kind.  \n" +
            "Love is not self-seeking.  \n" +
            "Love keeps no record of wrongs.  \n" +
            "Love always protects, always hopes, always perseveres."
    };
}]);
