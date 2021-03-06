function HomePage($scope, Category, Location, Information) {
    $scope.categories = Category.all();
    $scope.location = Location.all();
    $scope.information = Information.first();
}

function PersonDetailCtrl($scope, $routeParams, Person) {
    $scope.person = Person.first($routeParams);
}

function PersonCreateCtrl($scope, Category, Location, Person) {
    $scope.categories = Category.all();
    $scope.locations = Location.all();
    $scope.selectedCategories = [];
    $scope.selectCategory = function (categoryResource) {
        var category = categoryResource.value;
        if ($scope.selectedCategories.indexOf(category) === -1) {
            $scope.selectedCategories.push(category);
        } else {
            $scope.selectedCategories.splice($scope.selectedCategories.indexOf(category), 1);
        }
    };
    $scope.save = function () {
        var location = $scope.profile.location.value;
        $scope.profile.location = location;
        $scope.profile.categories = $scope.selectedCategories;
        $scope.profile.links = [];
        Person.save($scope.profile);
    };
}

function CategoryListCtrl($scope, Category) {
    $scope.categories = Category.all();
}

function CategoryDetailCtrl($scope, $routeParams, Category) {
    $scope.category = Category.first($routeParams);
}

function LocationListCtrl($scope, Location) {
    $scope.locations = Location.all();
}

function LocationDetailCtrl($scope, $routeParams, Location) {
    $scope.location = Location.first($routeParams);
}

function RandomPersonCtrl($window, Person) {
    Person.first(function(person) {
        $window.location.href = person.url;
    });
}

function ApprovalDetailCtrl($scope, $routeParams, $window, Approval) {
    $scope.approval = Approval.first($routeParams);

    $scope.approve = function () {
        Approval.approve({ id: $routeParams.id }, function(result) {
            $window.location.href = result.url;
        });
    };

    $scope.deny = function () {
        Approval.deny({ id: $routeParams.id }, function() {
            $window.location.href = '/';
        });
    }
}
