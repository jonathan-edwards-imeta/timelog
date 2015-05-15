(function () {
    'use strict';

    var bookingCodesService = angular.module('bookingCodesService', ['ngResource']);
      

    bookingCodesService.factory('bookingCodes', ['$resource',
      function ($resource) {
          return $resource('http://localhost\\:1324/api/bookingCode/', {}, {
              query: { method: 'GET', params: {}, isArray: true }
          });
      }]);

})();