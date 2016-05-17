angular.module('app').service('monthFinanceListService', 
function(){
    this.getMonthFinance = function($http)
    {
        var url = "MonthFinance/GetDocument";
        return    $http({
                method: 'GET',
                url: url}).then(function (response) {
                return response.data;
            });  
         
    }
});


