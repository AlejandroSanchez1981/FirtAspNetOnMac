using System;
using firstaspnet.Entities;
using firstaspnet.Models;
using firstaspnet.Interfaces.ioc;

namespace firstaspnet.Test.ContextMock
{
    public class MonthFinanceContextMock : IRepository<MonthFinance>
    {
        
        public MonthFinance GiveItem()
        {
            throw new NotImplementedException();
        }

        public MonthFinance GiveMonthPrevius()
        {
            
            var previusMonth = new MonthFinance{
               Name = DateTime.Now.AddMonths(-1).ToMonthName() + DateTime.Now.Year.ToString(),
                MonthExpensive = null,
                MonthEarning = null,
                Saving = 0
            };
         
            return previusMonth;
        }

        public bool Save(MonthFinance month)
        {
            if(month != null)
            {
                double subtotalEarning = 0;
                double subtotalExpense = 0;
                
                foreach (var item in month.MonthExpensive.ListItemsExpense)
                {
                    subtotalExpense += item.HowMuch;
                }
                foreach (var item in month.MonthEarning.ListItemsEarning)
                {
                    subtotalEarning += item.HowMuch;
                }
                if(subtotalExpense == month.SubTotalExpense  && subtotalEarning == month.SubTotalEarning)
                    return true;    
            }
            
            
            return false;
        }
        
        
    }
}