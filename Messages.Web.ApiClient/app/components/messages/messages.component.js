'use strict';
app.component('messages', {
    templateUrl: '/app/components/messages/messages.view.html',
    controller: ['$scope', 'authService', 'messagesService', messagesController]
});

function messagesController($scope, authService, messagesService) {
    $scope.newMessage = {
        body: ''
    };
    $scope.messages = [];
    $scope.users = [];

    messagesService.getMessages(0, 5).then(
        function (results) {
            $scope.messages = results.data.messages;
            $scope.users = results.data.users;
        },
        function (error) {
            //alert(error.data.message);
        }
    );

    $scope.authentication = authService.authentication;

    $scope.addMessage = function() {

    };
}