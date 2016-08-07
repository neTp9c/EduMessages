app.component("loginMenu", {
    templateUrl: "/app/core/components/login-menu/login-menu.view.html",
    replace: 'true',
    controller: ['$scope', '$location', 'authService', loginMenuCtrl]
});

function loginMenuCtrl($scope, $location, authService) {

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/');
    }

    $scope.authentication = authService.authentication;
}