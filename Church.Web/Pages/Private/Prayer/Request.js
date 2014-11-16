define(["require", "exports", "Scripts/Common/Page"], function(require, exports, Page) {
    var topic = "";
    Page.addController("prayerRequest", [
        "$scope", "$window", "api", function ($scope, $window, api) {
            $scope.translations = {
                name: "Name",
                url: "URL",
                request: "Request"
            };
            $scope.data = {
                name: "",
                url: "",
                requestPrayer: function () {
                    var request = {
                        Topic: topic,
                        Name: $scope.data.name,
                        Url: $scope.data.url
                    };
                    api.post("/prayer/request", request).then(function (response) {
                        $window.location.hash = "Private/Welcome";
                    });
                }
            };
        }]);

    function initialize(path) {
        "use strict";
        topic = path[0];
        Page.setTitle("Request Prayer for " + topic);
    }
    exports.initialize = initialize;
});
//# sourceMappingURL=Request.js.map
