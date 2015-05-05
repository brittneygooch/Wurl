app.controller('EventController', function ($scope, CoreFactory, $routeParams, $location, $timeout) {

    // Array for all events
    $scope.EventArr = [];
    // So we can use $index in the {{}} part of ng-x stuff
    $scope.index = $routeParams.index;
    // Booleans for editing and new stuff
    $scope.isEditing = false;
    $scope.isAdding = false;
    $scope.changeCity = false;
    $scope.cityWait = false;
    // Wait message when posting to database
    $scope.wait = false;
    // Error message for an unsuccessful creation of new event
    $scope.createError = false;
    // Holders for event data when making a new one
    $scope.Title = "";
    $scope.ImageUrl = "";
    $scope.Description = "";
    $scope.Date = "";
    $scope.Time = "";
    $scope.Location = "";
    $scope.City = "";
    // Paginator
    $scope.page = function (num) {
        $scope.cPage = num - 1;
        $scope.counter = $scope.cPage * $scope.perPage;
        $scope.getStuff();
    };
    $scope.cPage = 0;
    $scope.counter = 0;
    $scope.perPage = 5;

    // List selector for which image to show on event
    $scope.Images = [
        { title: "Outdoors", text: "/images/outdooreventphotosmall.png" },
        { title: "House Party", text: "/images/housepartyeventphotosmall.png" },
        { title: "At the bar", text: "/images/barstockphotosmall.png" },
        { title: "Music", text: "/images/musiceventphotosmall.png" },
        { title: "Public Engagement", text: "/images/publicengagementeventphotosmall.png" }
    ];
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
            getAllEvents();
        });
    };
    // Get user info and set it
    if ($scope.status.loggedin == true) $scope.getUserInfo();

    // Set city in local storage
    function setUserCity() {
        console.log($scope.user.city);
        CoreFactory.getCity($scope.user.city);
    };
    if ($scope.status.loggedin == true) setUserCity();

    // Change city
    $scope.editCity = function () {
        $scope.changeCity = true;
    }

    $scope.CityChange = function () {
        $scope.cityWait = true;
        CoreFactory.getCity($scope.user.city);
        CoreFactory.allEvents().then(function (data) {
            $scope.EventArr = data;
            console.log($scope.EventArr)
            $scope.cityWait = false;
        });
        $scope.changeCity = false;
    }

    // Get all events based on that city
    function getAllEvents() {
        CoreFactory.allEvents().then(function (data) {
            $scope.EventArr = data;
        });
    };

    // Set the detailId in CoreFactory so we can get only one set of stuff
    $scope.getDetail = function (index) {
        console.log(index);
        CoreFactory.objDetailId(index);
        //$location.path("/someplace/" + index);
    }

    $scope.newEvent = function () {
        $scope.Title = "";
        $scope.url = "";
        $scope.Description = "";
        $scope.Date = "";
        $scope.Time = "";
        $scope.Location = "";
        $scope.City = "";
    }

    $scope.addNewEvent = function () {
        console.log($scope.url);
        var eventToPost = { Title: $scope.Title, Location: $scope.Location, City: $scope.City, Description: $scope.Description, UserId: $scope.user.userId, Date: $scope.Date, Time: $scope.Time, ImgUrl: $scope.url.text }
        $scope.wait = true;
        CoreFactory.addEvent(eventToPost).then(function (success) {
            $scope.Title = "";
            $scope.url = "";
            $scope.Description = "";
            $scope.Date = "";
            $scope.Time = "";
            $scope.Location = "";
            $scope.City = "";
            $location.path('/Events')
        }, function (error) {
            $scope.createError = true;
        });
    }

    $scope.editEvent = function (index) {
        $scope.getDetail(index);
        var currEvent = $scope.index;
        $scope.EventId = currEvent.thisEvent.eventId;
        $scope.Description = currEvent.thisEvent.description;
        $scope.Date = currEvent.thisEvent.date;
        $scope.Time = currEvent.thisEvent.time;
        $scope.Location = currEvent.location;
        $scope.isEditing = true;
    }

    $scope.updateEvent = function () {
        var eventToUpdate = { EventId: $scope.EventId, Description: $scope.Description, Date: $scope.Date, Time: $scope.Time, Location: $scope.Location }
        CoreFactory.updateEvent(eventToUpdate).then(function (data) {
            $scope.EventId = "";
            $scope.Description = "";
            $scope.Date = "";
            $scope.Time = "";
            $scope.Location = "";
            getAllEvents();
        }, function () {
            console.log("Error on line 89 of EventController");
        });
        $scope.isEditing = false;
    }

    $scope.deleteEvent = function (index) {
        $scope.getDetail(index);
        CoreFactory.deleteEvent();
        getAllEvents();
    }

    

})