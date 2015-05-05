app.controller('BoardDetailController', function ($scope, CoreFactory, $routeParams, $location) {

    $scope.index = $routeParams.index;

    $scope.localPostArr = {};
    $scope.localReplyArr = [];

    function postDetails() {
        CoreFactory.postDetails().then(function (data) {
            $scope.localPostArr = data.thatPost;
            console.log($scope.localPostArr);
            $scope.localReplyArr = data.allReplies;
            console.log($scope.localReplyArr)
        })
    }

    postDetails();

});