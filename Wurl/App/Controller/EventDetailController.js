app.controller('EventDetailController', function ($scope, CoreFactory, $routeParams, $location) {
    $scope.event = {};
    $scope.index = $routeParams.index;
    $scope.user = {};

    // User info from CoreFactory
    $scope.status = CoreFactory.status;
    console.log($scope.status);
    $scope.user = "";
    $scope.getUserInfo = function () {
        CoreFactory.getInfo().then(function (data) {
            console.log(data)
            $scope.user = data;
            console.log($scope.user.city);
            CoreFactory.getCity($scope.user.city);
        });
    };
    // Get user info and set it
    if ($scope.status.loggedin == true) $scope.getUserInfo();

    // Editing things
    $scope.isEditing;
    $scope.EventId = "";
    $scope.Title = "";
    $scope.Description = "";
    $scope.Date = "";
    $scope.Time = "";
    $scope.Location = "";

    function getEvent() {
        CoreFactory.getEvent().then(function (data) {
            localStorage.setItem('detail', data);
            $scope.event = data;
        }, function (error) {
            //$scope.event = localStorage.getItem('detail');
            var loc = window.location.href.split('/');
            CoreFactory.eGetEvent(loc[5]).then(function (data) {
                $scope.event = data;
            })
            console.log(loc);
            console.log($scope.event);
        })
    }
    getEvent();

    $scope.getDetail = function (index) {
        console.log(index);
        CoreFactory.objDetailId(index);
        //$location.path("/someplace/" + index);
    }

    $scope.editEvent = function (index) {
        var currEvent = $scope.event;
        $scope.EventId = currEvent.thatEvent.eventId;
        $scope.Title = currEvent.thatEvent.title;
        $scope.Description = currEvent.thatEvent.description;
        $scope.Date = currEvent.thatEvent.date;
        $scope.Time = currEvent.thatEvent.time;
        $scope.Location = currEvent.thatEvent.location;
        $scope.isEditing = true;
    }

    $scope.updateEvent = function () {
        var eventToUpdate = { EventId: $scope.EventId, Title: $scope.Title, Description: $scope.Description, Date: $scope.Date, Time: $scope.Time, Location: $scope.Location };
        $scope.event.thatEvent.eventId = $scope.EventId;
        $scope.event.thatEvent.title = $scope.Title;
        $scope.event.thatEvent.description = $scope.Description;
        $scope.event.thatEvent.date = $scope.Date;
        $scope.event.thatEvent.time = $scope.Time;
        $scope.event.thatEvent.location = $scope.Location;
        CoreFactory.updateEvent(eventToUpdate).then(function (data) {
            $scope.Title = "";
            $scope.EventId = "";
            $scope.Description = "";
            $scope.Date = "";
            $scope.Time = "";
            $scope.Location = "";
        }, function () {
            console.log("Error updating");
        });
        $scope.isEditing = false;
    }

    $scope.deleteEvent = function (index) {
        $scope.getDetail(index);
        CoreFactory.deleteEvent().then(function (data) {
            $location.path('/Events');
        });
    }
})