
angular.module('categoryServices', ['ngResource']).
factory('Category', function ($resource) {
    return $resource('/api/category/:id', { id: '@id' }, {
        all: { method: 'GET', isArray: true },
        first: { method: 'GET' }
    });
});

angular.module('personServices', ['ngResource']).
    factory('Person', function($resource) {
        return $resource('/api/person/:id', { id: '@id' }, {
            all: { method: 'GET', isArray: true },
            first: { method: 'GET' },
            save: { method: 'POST' }
        });
    });

angular.module('locationServices', ['ngResource']).
    factory('Location', function($resource) {
        return $resource('/api/location/:id', { id: '@id' }, {
            all: { method: 'GET', isArray: true },
            first: { method: 'GET' }
        });
    });

angular.module('approvalServices', ['ngResource']).
    factory('Approval', function($resource) {
        return $resource('/api/approval/:id', { id: '@id' }, {
            first: { method: 'GET' },
            approve: { method: 'POST' },
            deny: { method: 'DELETE' }
        });
    });

angular.module('informationServices', ['ngResource']).
    factory('Information', function($resource) {
        return $resource('/api/information', {}, {
            first: { method: 'GET' }
        });
    });
// http://docs.angularjs.org/tutorial/step_11

