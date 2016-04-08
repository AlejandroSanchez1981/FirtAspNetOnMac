using System;
using firstaspnet.Test.ContextMock;
using firtaspnet.Controllers;
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
        
        //if have previus moth load, show the new month with the data.
        [Fact]
        public void WhenHaveMonthPreviusCopyAllTheDataInTheNewMonthThenOk()
        {
            var context = new MonthFinanceContextMock();
        }
    }
}