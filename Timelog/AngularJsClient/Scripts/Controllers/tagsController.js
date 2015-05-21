(function () {
    'use strict';

    angular
        .module('app')
        .controller('tagsController', tagsController);

    tagsController.$inject = ['$scope', 'Tags'];

    function tagsController($scope, Tags) {
        $scope.tags = Tags.query();
    }

 
})();
