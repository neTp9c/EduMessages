app.factory('messagesService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:57199/';
    var messagesServiceFactory = {};

    var _addMessage = function (message) {
        return $http.post(serviceBase + 'api/v1/messages', message).then(function (response) {
            return response;
        });
    };

    var _getMessages = function (skip, take, userId) {
        return $http
            .get(serviceBase + 'api/v1/messages', {
                params: {
                    skip: skip,
                    take: take,
                    userId: userId
                }
            })
            .then(function (response) {
                response.data.messages.forEach(function (message) {
                    for (var j = 0; j < response.data.users.length; j++) {
                        if (message.userId == response.data.users[j].id) {
                            message.user = response.data.users[j];
                            break;
                        }
                    }
                });
                return response;
            });
    };

    messagesServiceFactory.getMessages = _getMessages;
    messagesServiceFactory.addMessage = _addMessage;

    return messagesServiceFactory;
}]);