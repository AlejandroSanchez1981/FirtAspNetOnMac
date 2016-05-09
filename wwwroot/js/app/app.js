(function () {
    'use strict';
 
    var app = angular.module('app', ['earningServices']);
    
    
    var earningServices = angular.module('earningServices', ['ngResource']);
 
    earningServices.factory('Earnings', ['$resource',
      function ($resource) {
          return $resource('@Url.Action("GetEarning", "MonthFinance" )', {}, {
              query: { method: 'GET', params: {}, isArray: true }
          });
      }]);
      



    app.controller('MonthFinanceController', function($scope, Earnings) {
        $scope.earnings = Earnings.query();
    });
 
    MonthFinanceController.$inject = ['$scope', 'Earnings'];
 
    


})();