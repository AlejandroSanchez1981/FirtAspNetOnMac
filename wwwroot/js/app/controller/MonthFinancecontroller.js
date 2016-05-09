(function () {
    'use strict';
 
    angular
        .module('app')
        .controller('MonthFinanceController', MonthFinanceController);
 
    MonthFinanceController.$inject = ['$scope', 'Earnings'];
 
    function MonthFinanceController($scope, Earnings) {
        $scope.earnings = Earnings.query();
    }
})();