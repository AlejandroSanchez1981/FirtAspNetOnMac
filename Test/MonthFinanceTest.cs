using System;
using System.Collections.Generic;
using firstaspnet.Data.Entities;
using firstaspnet.Entities;
using firstaspnet.Models;
using firstaspnet.Test.ContextMock;
using firtaspnet.Controllers;
using firtaspnet.Models;
using Microsoft.AspNet.Mvc;
using Xunit;

namespace firstaspnet.Test
{
    public class MonthFinanceTest
    {
        [Fact]
        public void WhenIfHaveFileItemThenSave()
        {
            /*
               For month i generate a file with data, the name must be complete.
            */
            var model = new MonthFinanceModel{
                ExpenseModel = null,
                EarningModel = null
            };
            
            var controller = new MonthFinanceController();
            var result = controller.Save(model);
            
            Assert.Equal(true, result);
        }
        
        [Fact]
        public void WhenHaveFileNameMustBeMonthAndYearThenTrue()
        {
            var result = false;
            var model = new MonthFinanceModel{
                ExpenseModel = null,
                EarningModel = null
            };
            
            if(model.Name == DateTime.Now.ToMonthName() + DateTime.Now.Year.ToString())
            {
                result = true;
            }
            
            Assert.Equal(true, result);
        }
        
        
        [Fact]
        public void WhenWantSaveThenSubtotalAreEsqualsThanHisList()
        {
            var context = new MonthFinanceContextMock();
            //create Model with properties.
            var earningModel = new EarningModel {ListItemsEarningModel = new List<ItemModel>{
                new ItemModel{Name = "Salary", HowMuch = 5000}
            }};
            
            if(earningModel == null)
             Assert.Equal(true,false);    
            
            var expenseModel = new ExpensesModel{ListItemsExpenseModel = new List<ItemModel>{
              new ItemModel {Name = "Rent House Dublin", HowMuch = 2500}  
            }};
            
            if(expenseModel == null)
             Assert.Equal(true,false);
             
            var monthFinanceEntity = new MonthFinanceModel{
                ExpenseModel = expenseModel,
                EarningModel = earningModel,
                Saving = 1000
            };
            
            if(monthFinanceEntity == null)
             Assert.Equal(true,false);
            
            var entity = monthFinanceEntity.ToModelToEntity();
            
            if(entity == null)
             Assert.Equal(true,false);
            
            //pass model to ententy
            //var result = context.Save(monthFinanceEntity.ToModelToEntity());
            //save
            var result = false;
            
            Assert.Equal(true,result);
            
        }
        
        //if have previus moth load, show the new month with the data.
        [Fact]
        public void WhenHaveMonthPreviusCopyAllTheDataInTheNewMonthThenOk()
        {
            var context = new MonthFinanceContextMock();
        }
    }
}