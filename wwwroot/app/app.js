'use strict';

 angular.module('app', ['ngRoute','chart.js']).config(['$routeProvider',
  function($routeProvider) {
    $routeProvider
      .when('/', {
      controller:'MonthFinanceController',
      templateUrl:'/MonthFinance/ListCurrentMonth'
    })
  }]);

