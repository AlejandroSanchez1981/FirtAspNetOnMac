'use strict';

angular.module('app').service('MonthFinanceListService', function monthFinanceListService() {
                return function getActualyMonth(){
                    return  {
	                         "Name":"April2016",
	                         "MonthExpensive":{ 
                                                "ListItemsExpense":
                                                        [
											                {"Name":"Rent House Dublin","HowMuch":2500.0}
										                ]
                                              },
                            "MonthEarning":
					                          { "ListItemsEarning":
                                                    [
					 						                {"Name":"Salary","HowMuch":5000.0}
					 					            ] 
					                          },
	                        "Saving":1000.0,
	                        "SubTotalExpense":2500.0,
	                        "SubTotalEarning":5000.0,
	                        "Total":5000.0,
	                        "Id":"efede5a3-0b4c-4d41-a054-55d1b97ae35e"
	                        }         
                        }
            });
 
 angular.module('app').service('monthFinanceSaveNewEarn', //['$scope',
 function ()
 {
     this.save = function (x){
         if(x)
            return true;                                    
         }
 }//]
 );