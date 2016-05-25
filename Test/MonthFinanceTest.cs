using System;
using System.Collections.Generic;
using firstaspnet.Data.Entities;
using firstaspnet.Entities;
using firstaspnet.Models;
using firstaspnet.Test.ContextMock;
using firstaspnet.Controllers;
using Microsoft.AspNet.Mvc;
using Xunit;

namespace firstaspnet.Test
{
    public class MonthFinanceTest
    {
        
        [Fact]
        public void WhenHaveFileNameMustBeMonthAndYearThenTrue()
        {
            var result = false;
            var model = new MonthFinanceModel{
                Expense = null,
                Earning = null
            };
            
            if(model.Name == DateTime.Now.ToMonthName() + DateTime.Now.Year.ToString())
            {
                result = true;
            }
            
            Assert.Equal(true, result);
        }
        
        
        [Fact]
        public void WhenWantSaveThenSubtotalAreEsqualsThatHisList()
        {
            var context = new MonthFinanceContextMock();
            //create Model with properties.
             var earningModel = new EarningModel {ListItemsEarningModel = new List<ItemModel>{
                new ItemModel{Name = "Salary", HowMuch = 5000}
            }};
            
            var expenseModel = new ExpensesModel{ListItemsExpenseModel = new List<ItemModel>{
              new ItemModel {Name = "Rent House Dublin", HowMuch = 2500}  
            }};
            
            var monthFinanceEntity = new MonthFinanceModel{
                Expense = expenseModel,
                //EarningModel = earningModel,
                Saving = 1000
            };
            
            var entity = monthFinanceEntity.ToModelToEntity();
            
            //entity.SubTotalEarning = 5000;
            //entity.SubTotalExpense = 2500;
           
            //pass model to ententy
            var result = context.Save(entity);
            
            Assert.Equal(true,result);
        }
        
        
    }
}