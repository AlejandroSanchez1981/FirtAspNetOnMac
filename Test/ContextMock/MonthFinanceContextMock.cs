using System;
using firtaspnet.Interfaces.ioc;

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
                Name = DateTime.Now.AddMonths(-1).ToMonthName() +DateTime.Now.Year.ToString()
            };
         
            return previusMonth;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}