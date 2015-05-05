app.controller('BoardController', ['$scope', 'CoreFactory', '$routeParams', '$location', function ($scope, CoreFactory, $routeParams, $location) {

    $scope.localPostArr = [];
    $scope.localReplyarr = [];
    $scope.index = $routeParams.index;
    $scope.isEditing = false;
    $scope.isAdding = false;

    // User info from CoreFactory
    $scope.status = CoreFactory.status;
    $scope.userInfo = {};
    $scope.getUserInfo = function () {
        LoginFactory.getInfo().then(function (data) {
            $scope.userInfo = data;
        });
    }
    if ($scope.status.loggedin) $scope.getUserInfo();
    // Holder for user data from CoreFactory
    $scope.savedUser = {};

    $scope.Title = "";
    $scope.Body = "";

    function getPosts() {
        CoreFactory.getPosts().then(function (data) {
            $scope.localPostArr = data.allPosts;

        })
    }
    getPosts();
    

    $scope.objDetailId = function (index) {
        console.log(index);
        CoreFactory.objDetailId(index);
        $location.path("/Details/" + index);
    }
    
    
    //$scope.postDetails = function (index) {
    //    CoreFactory.objDetailId(index);

    //    CoreFactory.postDetails().then(function (data) {
    //        $scope.localPostArr = data.ThatPost;
    //        $scope.localReplyarr = data.AllReplies;
    //    })
    //}

    $scope.newPost = function () {
        $scope.Title = "";
        $scope.Body = "";
        $scope.isAdding = true;
    }

    $scope.addPost = function () {
        $scope.savedUser = $scope.userInfo.username;
        var eventToPost = { Title: $scope.Title, Body: $scope.Body }
        CoreFactory.newPost(eventToPost).then(function (data) {
            $scope.Title = "";
            $scope.Body = "";
            $scope.isAdding = false;
        }, function () {
            console.log("Error on line 61 of PostController");
        });
        $location.path('/Board')
    
        
        }


    $scope.editPost = function (index) {
        CoreFactory.objDetailId(index).then(function (data) {
            $scope.Title = data.Title;
            $scope.Body = data.Body;
            $location.path("/Details/" + index);
        })
        $scope.isEditing = true;
    }
    


    $scope.updatePost = function () {
        var postToUpdate = {Title: $scope.Title, Body: $scope.Body}
        CoreFactory.updatePost(postToUpdate).then(function (data) {
            $scope.Title = "";
            $scope.Body = "";
            getPosts();
        })
        $scope.isEditing = false;
    }

    $scope.deletePost = function () {
        CoreFactory.deletePost().then(function (data) {
            $scope.localPostArr = data;
            $scope.getPosts();
        })
    }

}]);