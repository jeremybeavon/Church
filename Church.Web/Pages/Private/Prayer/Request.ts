import Page = require("Scripts/Common/Page");

var topic: string = "";
Page.addController("prayerRequest",
    ["$scope", "$window", "api", function ($scope: Page.IControllerScope, $window: ng.IWindowService, api: Page.IApi): void {
        $scope.translations = {
            name: "Name",
            url: "URL",
            request: "Request"
        };
        $scope.data = {
            name: "",
            url: "",
            requestPrayer: function (): void {
                var request: any = {
                    Topic: topic,
                    Name: $scope.data.name,
                    Url: $scope.data.url
                };
                api.post<any>("/prayer/request", request).then(function (response: any): void {
                    $window.location.hash = "Private/Welcome";
                });
            }
        };
    }]);

export function initialize(path: string[]): void {
    "use strict";
    topic = path[0];
    Page.setTitle("Request Prayer for " + topic);
}