define(["require", "exports", "Scripts/Common/Page"], function(require, exports, Page) {
    Page.addController("publicWelcome", [
        "$scope", function ($scope) {
            Page.setTitle("Welcome to Church");
            $scope.translations = {
                welcome: "You are deeply loved by God.  \n" + "Love is patient.  \n" + "Love is kind.  \n" + "Love is not self-seeking.  \n" + "Love keeps no record of wrongs.  \n" + "Love always protects, always hopes, always perseveres."
            };
        }]);
});
//# sourceMappingURL=Welcome.js.map
