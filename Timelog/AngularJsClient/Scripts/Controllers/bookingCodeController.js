(function () {
    'use strict';

    angular
        .module('app')
        .controller('bookingCodesController', bookingCodesController);

    bookingCodesController.$inject = ['$scope', 'bookingCodes'];

    function bookingCodesController($scope, bookingCodes) {
        $scope.bookingCodes = bookingCodes.query();
    }

 
})();
