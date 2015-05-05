app.factory('LoginFactory', function ($http, $q) {
    var status = {};
    if (localStorage.getItem('token')) status.loggedin = true;
    else status.loggedin = false;

    var login = function (user) {
        var def = $q.defer();
        $http({
            method: 'POST',
            url: '/Token',
            data: 'userName=' + user.username + '&password=' + user.password + '&grant_type=password',
            contentType: 'application/x-www-form-urlencoded'
        }).success(function (data) {
            localStorage.setItem('token', data.access_token);
            status.loggedin = true;
            def.resolve();
        }).error(function (data) {
            logout();
            def.reject();
        });
        return def.promise;
    }
    var logout = function () {
        localStorage.removeItem('token');
        status.loggedin = false;
    }

    var getInfo = function () {
        var def = $q.defer();
        $http({
            url: '/api/apiUser',
            method: 'GET'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    return {
        status: status,
        login: login,
        logout: logout,
        getInfo: getInfo
    }
})