app.controller('AccountController', function ($scope, CoreFactory) {
    $scope.status = CoreFactory.status;
    $scope.user = {
        username: '', password: ''
    }
    $scope.userInfo = {};
    $scope.login = function () {
        CoreFactory.login($scope.user).then(function () {
            $scope.getUserInfo();
        });
    }
    $scope.logout = CoreFactory.logout;

    $scope.getUserInfo = function () {
        CoreFactory.getInfo().then(function (data) {
            $scope.userInfo = data;
        });
    }
    if ($scope.status.loggedin) $scope.getUserInfo();
})