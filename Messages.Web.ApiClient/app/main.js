var app = angular.module('MessagesApp', [
    'ngRoute',
    'LocalStorageModule',
    //'angular-loading-bar',
]);

app.config(function ($routeProvider) {

    $routeProvider.when("/", {
        template: "<messages></messages>"
    });

    $routeProvider.when("/login", {
        template: "<login></login>"
    });

    $routeProvider.when("/signup", {
        template: "<signup></signup>"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);