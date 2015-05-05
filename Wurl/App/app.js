var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider, $httpProvider) {
    $routeProvider.when('/', {
        templateUrl: '/app/views/Home.html',
        title: 'Home Page',
        controller: 'HomeController'
    }).when('/Board', {
        templateUrl: 'app/views/Board.html',
        title: 'Message Board',
        controller: 'BoardController'
    }).when('/EditBoardPost/:index', {
        templateUrl: 'app/views/EditBoardPost.html',
        title: 'Edit Post',
        controller: 'BoardController'
     }).when('/Events', {
        templateUrl: '/app/views/upcomingevents.html',
        title: 'Local Events',
        controller: 'EventController'
    }).when('/Event/:index', {
        templateUrl: 'app/views/EventDetail.html',
        title: 'Event Detail',
        controller: 'EventDetailController'
    }).when('/EditEvent', {
        controller: 'EventController',
        templateUrl: 'app/Views/EditEvent.html',
        title: 'Edit Event'
    }).when('/Details/:index', {
        controller: 'BoardDetailController',
        templateUrl: 'app/Views/Details.html',
        title: 'Post Details'
    }).when('/CreateEvent', {
        controller: 'EventController',
        templateUrl: 'app/Views/CreateEvent.html',
        title: 'Create Event'
    }).when('/Board/Create', {
        controller: 'BoardController',
        templateUrl: 'app/Views/MBCreate.html',
        title: 'CreateBoard'
    }).when('/Login', {
        controller: 'HomeController',
        templateUrl: 'app/views/Login.html',
        title: 'Login'
    }).when('/Register', {
        controller: 'HomeController',
        templateUrl: 'app/views/Register.html',
        title: 'Register'
    }).when('/Dash', {
        controller: 'HomeController',
        templateUrl: 'app/views/profileView.html',
        title: 'Dashboard'
    }).otherwise({
        redirectTo: '/'
    });
    $httpProvider.interceptors.push('AuthFactory');
})