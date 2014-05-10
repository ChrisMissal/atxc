function HomePage($scope, Person, Category, Location) {
    $scope.people = Person.all();
    $scope.categories = Category.all();
    $scope.location = Location.all();
}

function PersonListCtrl($scope, Person) {
    $scope.people = Person.all();
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
        console.log($scope.profile);
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
