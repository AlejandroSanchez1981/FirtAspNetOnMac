angular.module('test', []);

angular.module('test').controller('dataDebtController', 
    function name($scopes) 
    {
        var data =  { name = "Rent House Dublin", howmuch = 2500};
        $scope.debts = data;
         
    })
    
    
    app.controller('MonthFinanceController', function($scope, $http){
          var url = "MonthFinance/GetEarning";
          $http({
            method: 'GET',
            url: url}).then(function (response) {
            $scope.earnings = response.data;
          });
        });