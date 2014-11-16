define(["require", "exports", "Scripts/Common/Page"], function(require, exports, Page) {
    Page.addController("prayerNeeds", [
        "$scope", "$sce", function ($scope, $sce) {
            $scope.data = {
                Url: $sce.trustAsResourceUrl("https://www.wvi.org/burundi/article/hope-orphan-girl")
            };
        }]);
});
//# sourceMappingURL=Needs.js.map
