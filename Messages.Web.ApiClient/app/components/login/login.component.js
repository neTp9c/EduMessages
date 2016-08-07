app.component('login', {
    templateUrl: "/app/components/login/login.view.html",
    controller: ['$scope', '$location', 'authService', loginCtrl]
});

function loginCtrl($scope, $location, authService) {
    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {
        authService.login($scope.loginData).then(
            function (response) {
                $location.path('/');
            },
            function (err) {
                $scope.message = err.error_description;
            }
        );
    };
}