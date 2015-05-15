(function () {
    'use strict';

    var tagsService = angular.module('tagsService', ['ngResource']);
      

    tagsService.factory('Tags', ['$resource',
      function ($resource) {
          return $resource('http://localhost\\:1324/api/tag/', {}, {
              query: { method: 'GET', params: {}, isArray: true }
          });
      }]);

})();