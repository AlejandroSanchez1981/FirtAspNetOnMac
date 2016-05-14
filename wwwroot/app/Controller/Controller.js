'use strict';

angular.module('app').controller('MonthFinanceController', function name($scope, MonthFinanceListService) 
            {
                $scope.debts = MonthFinanceListService();
            });