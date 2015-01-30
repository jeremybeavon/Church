declare var MarkdownDeep: any;

var requestValidationToken: string = "";
var churchApp: ng.IModule = angular.module("ChurchApp", []);

(function initializeMarkdown(): void {
    var markdown: any = new MarkdownDeep.Markdown();
    markdown.ExtraMode = true;
    markdown.SafeMode = true;
    churchApp.directive("bindMarkdown", function ($compile: any): any {
        return function ($scope: any, $element: any, $attrs: any): void {
            $scope.$watch($attrs.bindMarkdown, function (newMarkdown: any): void {
                if (newMarkdown) {
                    $element.html("").append($compile(markdown.Transform(newMarkdown))($scope));
                }
            });
        };
    });
    churchApp.directive("markdownEditor", function (): any {
        return function ($scope: any, $element: any): void {
            (<any>$($element[0])).MarkdownDeep({
                help_location: "Scripts/mdd_help.htm",
                disableTabHandling: true
            });
        };
    });
})();


churchApp.factory("api", ["$http", function ($http: ng.IHttpService): any {
    return {
        post<T>(url: string, data: any): ng.IPromise<T> {
            return $http.post(url, data, {
                headers: { "X-RequestValidationToken": requestValidationToken }
            });
        },
        get<T>(url: string): ng.IPromise<T> {
            return $http.get(url, {
                headers: { "X-RequestValidationToken": requestValidationToken }
            });
        }
    };
}]);

var masterPageScope: any;
var pageDetails: any = {
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

var loginStatus: any = {
    Success: 1,
    IncorrectUserNameOrPassword: 2
};

class Page {
    public static login($location: ng.ILocationService, api: IApi): void {
        var request: any = {
            UserName: pageDetails.login.userName,
            Password: pageDetails.login.password
        };

        api.post<any>("login", request).success(function (response: any): void {
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
                updateMasterPage();
            }
        });
    }

    public static navigate($location: ng.ILocationService): void {
        var pageName: string = $location.path();
        if (pageName.indexOf("#") === 0) {
            pageName = pageName.substr(1);
        }

        var jsPath: string;
        var htmlPath: string;
        var area: string;
        var path: string[] = [];
        if (pageName) {
            var pageNameSplit: string[] = pageName.split("/");
            var page: string;
            var action: string;
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
            pageName = "Pages/" + area + "/" + page + "/" + action;
            jsPath = pageName + ".js";
            htmlPath = pageName + ".html";
        } else {
            area = "public";
            jsPath = "Pages/Public/Welcome/Welcome.js";
            htmlPath = "Pages/Public/Welcome/Welcome.html";
        }

        pageDetails.showLogin = jsPath.toLowerCase() === "pages/public/welcome/welcome.js" || requestValidationToken === "";
        if (area.toLowerCase() === "public" || requestValidationToken !== "") {
            require([jsPath], function (page: any): void {
                pageDetails.url = htmlPath;
                Page.initialize(page, path, (): void => updateMasterPage());
            });
        } else {
            updateMasterPage();
        }
    }

    public static initialize(page: any, path: string[], callback?: () => void): void {
        if (page && page.initialize !== undefined) {
            (<IHasInitialize>page).initialize(path);
        }

        if (callback) {
            callback();
        }
    }
}

export interface IApi {
    post<T>(url: string, data: any): ng.IHttpPromise<T>;
    get<T>(url: string): ng.IHttpPromise<T>;
}

export interface IControllerScope {
    translations: any;
    data: any;
    $apply: () => void;
}

export interface IHasInitialize {
    initialize(paths?: string[]): void;
}

export var addController: (name: string, inlineConstructor: any[]) => void = churchApp.controller;
churchApp.config(function ($controllerProvider: any): void {
    addController = $controllerProvider.register;
});

export function initialize(): void {
    "use strict";
    churchApp.controller("church", ["$scope", "$location", "api",
        function ($scope: any, $location: ng.ILocationService, api: IApi): void {
            $scope.translations = {
                userName: "User Name",
                password: "Password",
                logIn: "Log in",
                loginFailed: "User name or password incorrect."
            };
            pageDetails.login.login = function (): void {
                Page.login($location, api);
            };
            $scope.data = pageDetails;
            $scope.$on("$locationChangeSuccess", function (): void {
                Page.navigate($location);
            });
            masterPageScope = $scope;
        }]);
    Page.initialize({}, [], (): void => {
        angular.bootstrap(document, ["ChurchApp"]);
        $(".show-on-bootstrap").show();
    });
}

export function setTitle(title: string): void {
    "use strict";
    pageDetails.title = title;
}

export function updatePage($scope: any): void {
    "use strict";
    if (!$scope.$$phase && (!$scope.$root || !$scope.$root.$$phase)) {
        $scope.$apply();
    }
}

export function updateMasterPage(): void {
    "use strict";
    updatePage(masterPageScope);
}