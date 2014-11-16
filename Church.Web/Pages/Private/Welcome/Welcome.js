define(["require", "exports", "Scripts/Common/Page"], function(require, exports, Page) {
    Page.addController("welcome", [
        "$scope", "api", function ($scope, api) {
            Page.setTitle("Welcome to Church");
            $scope.data = {
                Id: "Burundi",
                Requests: []
            };
            return api.get("/prayer/needs/Burundi").success(function (data) {
                $scope.data.Requests = data;
                return data;
            });
        }]);
});
//# sourceMappingURL=Welcome.js.map
