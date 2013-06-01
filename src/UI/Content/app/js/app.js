var partialsDir = 'Content/app/partials/';

angular.module('people', ['personServices', 'categoryServices', 'locationServices']).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.
            when('/', { templateUrl: partialsDir + 'index.html', controller: HomePage }).
            when('/add-profile', { templateUrl: partialsDir + 'profile-add.html', controller: PersonCreateCtrl }).
            when('/category', { templateUrl: partialsDir + 'category-list.html', controller: CategoryListCtrl }).
            when('/category/:id', { templateUrl: partialsDir + 'category-detail.html', controller: CategoryDetailCtrl }).
            when('/profile', { templateUrl: partialsDir + 'profile-list.html', controller: PersonListCtrl }).
            when('/profile/:id', { templateUrl: partialsDir + 'profile-detail.html', controller: PersonDetailCtrl }).
            otherwise({ redirectTo: '/' });
    }]);
