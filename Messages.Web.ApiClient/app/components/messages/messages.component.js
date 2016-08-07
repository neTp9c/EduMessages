'use strict';
app.component('messages', {
    templateUrl: '/app/components/messages/messages.view.html',
    controller: ['$scope', 'authService', 'messagesService', messagesController]
});

function messagesController($scope, authService, messagesService) {
    $scope.newMessage = {
        body: ''
    };
    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.messages = [];
    $scope.users = [];

    var _loadMessages = function () {
        messagesService.getMessages(($scope.currentPage - 1) * $scope.pageSize, $scope.pageSize, $scope.userId).then(
            function (results) {
                $scope.messages = results.data.messages;
                $scope.users = results.data.users;
                $scope.totalItems = results.data.totalMessagesCount;
            },
            function (error) {
                //alert(error.data.message);
            }
        );
    };

    $scope.authentication = authService.authentication;

    $scope.addMessage = function() {
        messagesService.addMessage($scope.newMessage).then(
            function (results) {
                $scope.newMessage.body = '';

                $scope.currentPage = 1;
                _loadMessages();

                $scope.message = 'New message was added sucessfully!';
                $scope.savedSuccessfully = true;

            },
            function (error) {
                $scope.message = 'Some error occur!';
                $scope.savedSuccessfully = false;
            }
        );
    };

    $scope.totalItems = 0;
    $scope.currentPage = 1;
    $scope.pageSize = 4;
    $scope.userId = '';

    $scope.pageChanged = function () {
        _loadMessages();
    };

    _loadMessages();
}