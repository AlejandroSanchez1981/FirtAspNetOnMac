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
        public ExpensesModel ExpenseModel { get; set; }
        public IEnumerable<ItemModel> EarningModels { get; set; }
        public double Saving { get; set; }
        public MonthFinanceModel()
        {
            Name = DateTime.Now.ToMonthName() + DateTime.Now.Year.ToString();
        }
    }

    public static class MonthFinanceExtensions
    {
        public static MonthFinanceModel ToMonthFinanceModel(this MonthFinance monthFinance)
        {
            var monthFinanceModel = new MonthFinanceModel {
                Name = monthFinance.Name,
                Saving = monthFinance.Saving,
                EarningModels = monthFinance.MonthEarning.ListItemsEarning.Select(x=>x.ToEntityModel())
            };
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
