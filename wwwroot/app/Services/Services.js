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
    
    this.SaveMonthFinance = function($http, monthFinances)
    {                           
        var url = "MonthFinance/SaveMonthFinance/";
       
        return $http.post(url, monthFinances)
            .success(function (data, status, headers, config) {

            }).error(function (data, status, headers, config) {

            });
        
    }
});


