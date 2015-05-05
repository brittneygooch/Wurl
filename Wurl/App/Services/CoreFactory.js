app.factory('CoreFactory', function ($http, $q) {
    //Set the detail Id to grab appropriate id from database (angular uses an array starting at zero, our tables start at 1)
    var detailId = "";
    var city = "";
    var postArr = [];

    // Login and user control
    var status = {};
    if (localStorage.getItem('token')) status.loggedin = true;
    else status.loggedin = false;

    // Registration
    var register = function (newUser) {
        var def = $q.defer();
        $http({
            method: 'POST',
            url: '/api/Account/Register',
            data: newUser,
            contentType: 'application/x-www-form-urlencoded'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    var usercheck = function (username) {
        var def = $q.defer();
        $http({
            method: 'GET',
            url: '/userCheck/' + username
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Login and logout
    var login = function (user) {
        var def = $q.defer();
        $http({
            method: 'POST',
            url: '/Token',
            data: 'username=' + user.username + '&password=' + user.password + '&grant_type=password',
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
            url: '/getUser',
            method: 'GET'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Pagination stuff
    var pagination = {
        page: 0,
        amountPerPage: 10
    }

    ///////////////// Post stuff ///////////////////////
    // Get Home page posts (only shows newest three posts)
    var getHomePosts = function() {
        var def = $q.defer();
        $http({
            method: 'GET',
            url: '/homePosts'
        }).success(function(data){
            def.resolve(data);
        }).error(function(data){
            def.reject(data);
        });
        return def.promise;
    }

    // Get all posts

    var getAllPosts = function () {
        var def = $q.defer();
        $http({
            method: 'GET',
            url: '/getPosts'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }
    // Get user city
    var getCity = function (currCity) {
        city = currCity;
        console.log(city);
    }

    // Get detail id (id for use later)
    var getDetailId = function (currId) {
        detailId = currId;
    }

    // API call to db for post detail with replies
    var getDetails = function () {
        var def = $q.defer();
        $http({
            method: 'GET',
            url: '/getPostDetail/' + detailId
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Create new post
    var addPost = function (newPost) {
        var def = $q.defer();
        $http({
            method: 'POST',
            url: '/createPost',
            data: newPost
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Get details for future edit
    var editPost = function () {
        var def = $q.defer();
        $http({
            method: 'GET',
            url: '/editPost/' + detailId
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Actually update the post
    var updatePost = function (postToUpdate) {
        var def = $q.defer();
        $http({
            url: '/updatePost',
            method: 'PATCH',
            data: postToUpdate
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Soft delete a post
    var deletePost = function () {
        var def = $q.defer();
        $http({
            url: '/deletePost/' + detailId,
            method: 'DELETE'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    ///////////////// Reply stuff ///////////////////////

    // Add a reply
    var newReply = function (replyData) {
        var def = $q.defer();
        $http({
            url: '/createReply',
            method: 'POST',
            data: replyData
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Get details to edit a reply
    var editReply = function () {
        var def = $q.defer();
        $http({
            url: '/editReply/' + detailId,
            method: 'GET'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Update a reply
    var updateReply = function (replyObj) {
        var def = $q.defer();
        $http({
            url: '/updateReply',
            method: 'PATCH',
            data: replyObj
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Soft delete a reply
    var deleteReply = function () {
        var def = $q.defer();
        $http({
            url: '/deleteReply/' + detailId,
            method: 'DELETE'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    ///////////////// Event stuff ///////////////////////

    // Get all events
    var getAllEvents = function () {
        var def = $q.defer();
        $http({
            url: '/getEvents/' + city,
            method: 'GET'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Get single event details
    var getEvent = function (index) {
        var def = $q.defer();
        $http({
            url: '/eventDetail/' + detailId,
            method: 'GET'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // On error get event details fur sure
    var eGetEvent = function (index) {
        var def = $q.defer();
        $http({
            url: '/eventDetail/' + index,
            method: 'GET'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Add new event
    var addEvent = function (editObj) {
        var def = $q.defer();
        $http({
            url: '/createEvent',
            method: 'POST',
            data: editObj
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Get edit details for an event
    var editEvent = function (data) {
        var def = $q.defer();
        $http({
            url: '/editEvent/' + detailId,
            method: 'GET'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Update edited event
    var updateEvent = function (editObj) {
        var def = $q.defer();
        $http({
            url: '/updateEvent',
            method: 'POST',
            data: editObj
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject();
        });
        return def.promise;
    }

    // Soft delete event
    var deleteEvent = function () {
        var def = $q.defer();
        $http({
            url: '/deleteEvent/' + detailId,
            method: 'PATCH'
        }).success(function (data) {
            def.resolve(data);
        }).error(function (data) {
            def.reject(data);
        });
        return def.promise;
    }

    // Return values for the controllers
    return {
        // Account stuff
        status: status,
        register: register,
        usercheck: usercheck,
        login: login,
        logout: logout,
        getInfo: getInfo,
        getCity: getCity,
        // post api calls
        getHome: getHomePosts,
        objDetailId: getDetailId,
        getPosts: getAllPosts,
        postDetails: getDetails,
        newPost: addPost,
        editPost: editPost,
        updatePost: updatePost,
        deletePost: deletePost,
        // reply api calls
        newReply: newReply,
        editReply: editReply,
        updateReply: updateReply,
        deleteReply: deleteReply,
        // event api calls
        allEvents: getAllEvents,
        getEvent: getEvent,
        eGetEvent: eGetEvent,
        addEvent: addEvent,
        editEvent: editEvent,
        updateEvent: updateEvent,
        deleteEvent: deleteEvent
    }
})