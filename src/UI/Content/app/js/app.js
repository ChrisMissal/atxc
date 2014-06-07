var partialsDir = 'Content/app/partials/';

angular.module('people', ['personServices', 'categoryServices', 'locationServices', 'approvalServices']).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
            when('/', { templateUrl: partialsDir + 'index.html', controller: HomePage }).
            when('/add-profile', { templateUrl: partialsDir + 'profile-add.html', controller: PersonCreateCtrl }).
            when('/categories', { templateUrl: partialsDir + 'category-list.html', controller: CategoryListCtrl }).
            when('/category/:id', { templateUrl: partialsDir + 'category-detail.html', controller: CategoryDetailCtrl }).
            when('/locations', { templateUrl: partialsDir + 'location-list.html', controller: LocationListCtrl }).
            when('/location/:id', { templateUrl: partialsDir + 'location-detail.html', controller: LocationDetailCtrl }).
            when('/profile/:id', { templateUrl: partialsDir + 'profile-detail.html', controller: PersonDetailCtrl }).
            when('/random', { templateUrl: partialsDir + 'profile-detail.html', controller: RandomPersonCtrl }).
            when('/approval/:id', { templateUrl: partialsDir + 'approval-detail.html', controller: ApprovalDetailCtrl }).
            otherwise({ redirectTo: '/' });
    }]);
