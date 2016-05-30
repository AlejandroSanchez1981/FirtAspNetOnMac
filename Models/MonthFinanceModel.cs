using System;
using System.Globalization;
using firstaspnet.Entities;
using System.Linq;
using System.Collections.Generic;

namespace firstaspnet.Models
{
    public class MonthFinanceModel
    {
        public string Name { get; set; }
        public ExpensesModel Expense { get; set; }
        public EarningModel Earning { get; set; }
        public double Saving { get; set; }
        public MonthFinanceModel()
        {
             Name = DateTime.Now.ToMonthName() + DateTime.Now.Year.ToString();
             Earning = new EarningModel();
             Expense = new ExpensesModel();
        }
    }

    public static class MonthFinanceExtensions
    {
        public static MonthFinanceModel ToMonthFinanceModel(this MonthFinance source)
        {
            var monthFinanceModel = new MonthFinanceModel {
                Name = source.Name,
                Saving = source.Saving
            };
            monthFinanceModel.Earning.ListItemsEarningModel = source.MonthEarning.ListItemsEarning.Select(x => x.ToEntityModel());
            return monthFinanceModel;
        }
    }

    public static class DateTimeExtensions
    {
        public static string ToMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

    }    
}
