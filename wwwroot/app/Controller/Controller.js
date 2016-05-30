'use strict';

angular.module('app').controller('MonthFinanceController', 
            function name($scope, $http, monthFinanceListService) 
            {
                var data = monthFinanceListService.getMonthFinance($http);
                data.then(function(data)
                {
                  $scope.monthFinances = data;
                })
                
                $scope.addEarning = function() {
                    $scope.monthFinances.Earning.ListItemsEarningModel.push({Name: '', HowMuch: ''});
                };
                
                $scope.save = function()
                {
                  monthFinanceListService.SaveMonthFinance($http, $scope.monthFinances);
                }
            });
 
 
 angular.module('app').controller("LineCtrl", function ($scope) {  
            $scope.labels = ["January", "February", "March", "April", "May", "June", "July"];
            $scope.series = ['Ingresos', 'Gastos', 'Inversiones'];
            $scope.data = [
              [13000, 13000, 20000, 18000, 22000, 13000, 13000],
              [3000, 3000, 3000, 9000, 3000, 5000, 7000],
            [3000, 5000, 8000, 12000, 16000, 18000, 12000]
            ];
          $scope.onClick = function (points, evt) {
            console.log(points, evt);
          };
      });


/*
function monthFinance($scope, $http, monthFinanceListService)
{
    var data = monthFinanceListService.getMonthFinance($http);
                data.then(function(data)
                {
                  $scope.monthFinances = data;
                })
}


function SettingsController1() {
  this.name = "John Smith";
  this.contacts = [
    {type: 'phone', value: '408 555 1212'},
    {type: 'email', value: 'john.smith@example.org'} ];
}

SettingsController1.prototype.greet = function() {
  alert(this.name);
};

SettingsController1.prototype.addContact = function() {
  this.contacts.push({type: 'email', value: 'yourname@example.org'});
};

SettingsController1.prototype.removeContact = function(contactToRemove) {
 var index = this.contacts.indexOf(contactToRemove);
  this.contacts.splice(index, 1);
};

SettingsController1.prototype.clearContact = function(contact) {
  contact.type = 'phone';
  contact.value = '';
};


 */















    
    