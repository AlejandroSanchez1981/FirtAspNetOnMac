using System;
using System.Globalization;

public class MonthFinanceModel
{
    public string Name { get; set; }
    public ExpensesModel ExpenseModel { get; set; }
    public EarningModel EarningModel { get; set; }
    
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
            Name = monthFinance.Name
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