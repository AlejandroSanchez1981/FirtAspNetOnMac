(function () {
    'use strict';
 
    var earningServices = angular.module('earningServices', ['ngResource']);
 
    earningServices.factory('Earnings', ['$resource',
      function ($resource) {
          return $resource('/monthfinance/GetEarning/', {}, {
              query: { method: 'GET', params: {}, isArray: true }
          });
      }]);
 
 
})();