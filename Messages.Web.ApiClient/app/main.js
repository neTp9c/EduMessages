var app = angular.module('MessagesApp', [
    'ngRoute',
    'LocalStorageModule',
    'ui.bootstrap'
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

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);