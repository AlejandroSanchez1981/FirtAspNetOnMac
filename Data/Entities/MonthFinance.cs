using firstaspnet.Data.Entities;
using firstaspnet.Models;

namespace firstaspnet.Entities
{
    public class MonthFinance : EntityBase
    {
        public MonthFinance()
        {
        }
        internal bool IsDefault;
        public string Name { get; set; }
        public Expense MonthExpensive { get; set; }
        public Earning MonthEarning { get; set; }
        public double Saving { get; set; }
        public double SubTotalExpense  { get; set; }
        public double SubTotalEarning { get; set; }
        public double Total { get; set; }
        
        public MonthFinance(string name, Expense monthExpensiveLast, double saving)
        {
            this.Name = name;
            this.MonthExpensive = monthExpensiveLast;
            //this.MonthEarning = monthEarningLast;
            this.Saving = saving;
        }
    }
    
    
    public static class MonthFinanceModelExtensions
    {
        public static MonthFinance ToModelToEntity(this MonthFinanceModel model)
        {
            if(model == null)
                return null;
                
            var monthFinance = new MonthFinance(
               model.Name,
               model.ExpenseModel.ToModelToEntity(),
               //model.EarningModel.ToModelToEntity(),
               model.Saving
            );
            
            monthFinance.SubTotalEarning = model.ExpenseModel.SumExpense();
            //monthFinance.SubTotalExpense = model.EarningModel.SumEarning();
            monthFinance.Total = monthFinance.SubTotalEarning + monthFinance.SubTotalExpense; 
            
            return monthFinance;
        }
    }
}