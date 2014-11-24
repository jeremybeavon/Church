define(["require", "exports"], function(require, exports) {
    var requestValidationToken = "";
    var churchApp = angular.module("ChurchApp", []);

    (function initializeMarkdown() {
        var markdown = new MarkdownDeep.Markdown();
        markdown.ExtraMode = true;
        markdown.SafeMode = true;
        churchApp.directive("bindMarkdown", function ($compile) {
            return function ($scope, $element, $attrs) {
                $scope.$watch($attrs.bindMarkdown, function (newMarkdown) {
                    if (newMarkdown) {
                        $element.html("").append($compile(markdown.Transform(newMarkdown))($scope));
                    }
                });
            };
        });
        churchApp.directive("markdownEditor", function () {
            return function ($scope, $element) {
                $($element[0]).MarkdownDeep({
                    help_location: "Scripts/mdd_help.htm",
                    disableTabHandling: true
                });
            };
        });
    })();

    churchApp.factory("api", [
        "$http", function ($http) {
            return {
                post: function (url, data) {
                    return $http.post(url, data, {
                        headers: { "X-RequestValidationToken": requestValidationToken }
                    });
                },
                get: function (url) {
                    return $http.get(url, {
                        headers: { "X-RequestValidationToken": requestValidationToken }
                    });
                }
            };
        }]);

    var masterPageScope;
    var pageDetails = {
        url: "",
        title: "",
        showLogin: requestValidationToken === "",
        showLoginFailed: false,
        login: {
            userName: "",
            password: "",
            login: null
        }
    };

    var loginStatus = {
        Success: 1,
        IncorrectUserNameOrPassword: 2
    };

    var Page = (function () {
        function Page() {
        }
        Page.login = function ($location, api) {
            var request = {
                UserName: pageDetails.login.userName,
                Password: pageDetails.login.password
            };

            api.post("/login", request).success(function (response) {
                if (response.LoginStatus === loginStatus.Success) {
                    requestValidationToken = response.RequestValidationToken;
                    pageDetails.showLogin = false;
                    if ($location.hash().indexOf("Private") > 0) {
                        Page.navigate($location);
                    } else {
                        $location.path("Private/Welcome");
                    }
                } else {
                    pageDetails.showLoginFailed = true;
                    exports.updateMasterPage();
                }
            });
        };

        Page.navigate = function ($location) {
            var pageName = $location.path();
            if (pageName.indexOf("#") === 0) {
                pageName = pageName.substr(1);
            }

            var jsPath;
            var htmlPath;
            var area;
            var path = [];
            if (pageName) {
                var pageNameSplit = pageName.split("/");
                var page;
                var action;
                if (pageNameSplit[0] === "") {
                    area = pageNameSplit[1];
                    page = pageNameSplit[2];
                    action = pageNameSplit.length > 3 ? pageNameSplit[3] : page;
                    if (pageNameSplit.length > 4) {
                        path = pageNameSplit.splice(4);
                    }
                } else {
                    area = pageNameSplit[0];
                    page = pageNameSplit[1];
                    action = pageNameSplit.length > 2 ? pageNameSplit[2] : page;
                    if (pageNameSplit.length > 3) {
                        path = pageNameSplit.splice(3);
                    }
                }
                pageName = "/Pages/" + area + "/" + page + "/" + action;
                jsPath = pageName + ".js";
                htmlPath = pageName + ".html";
            } else {
                area = "public";
                jsPath = "/Pages/Public/Welcome/Welcome.js";
                htmlPath = "/Pages/Public/Welcome/Welcome.html";
            }

            pageDetails.showLogin = jsPath.toLowerCase() === "/pages/public/welcome/welcome.js" || requestValidationToken === "";
            if (area.toLowerCase() === "public" || requestValidationToken !== "") {
                require([jsPath], function (page) {
                    pageDetails.url = htmlPath;
                    Page.initialize(page, path, function () {
                        return exports.updateMasterPage();
                    });
                });
            } else {
                exports.updateMasterPage();
            }
        };

        Page.initialize = function (page, path, callback) {
            if (page && page.initialize !== undefined) {
                page.initialize(path);
            }

            if (callback) {
                callback();
            }
        };
        return Page;
    })();

    exports.addController = churchApp.controller;
    churchApp.config(function ($controllerProvider) {
        exports.addController = $controllerProvider.register;
    });

    function initialize() {
        "use strict";
        churchApp.controller("church", [
            "$scope", "$location", "api",
            function ($scope, $location, api) {
                $scope.translations = {
                    userName: "User Name",
                    password: "Password",
                    logIn: "Log in",
                    loginFailed: "User name or password incorrect."
                };
                pageDetails.login.login = function () {
                    Page.login($location, api);
                };
                $scope.data = pageDetails;
                $scope.$on("$locationChangeSuccess", function () {
                    Page.navigate($location);
                });
                masterPageScope = $scope;
            }]);
        Page.initialize({}, [], function () {
            angular.bootstrap(document, ["ChurchApp"]);
            $(".show-on-bootstrap").show();
        });
    }
    exports.initialize = initialize;

    function setTitle(title) {
        "use strict";
        pageDetails.title = title;
    }
    exports.setTitle = setTitle;

    function updatePage($scope) {
        "use strict";
        if (!$scope.$$phase && (!$scope.$root || !$scope.$root.$$phase)) {
            $scope.$apply();
        }
    }
    exports.updatePage = updatePage;

    function updateMasterPage() {
        "use strict";
        exports.updatePage(masterPageScope);
    }
    exports.updateMasterPage = updateMasterPage;
});
//# sourceMappingURL=Page.js.map
