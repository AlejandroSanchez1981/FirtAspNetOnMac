using System.Collections.Generic;
using System.Linq;
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
        public double Saving { get; }
        public double SubTotalExpense  { get; }
        public double SubTotalEarning { get; }
        public double Total { get; set; }
        
        public MonthFinance(string name, Expense monthExpensiveLast, double saving)
        {
            this.Name = name;
            this.MonthExpensive = monthExpensiveLast;
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
               model.Expense.ToModelToEntity(),
               model.Saving
            );
            
            monthFinance.MonthEarning.ListItemsEarning = model.Earning.ToModelToEntity().ListItemsEarning;
            monthFinance.Total = monthFinance.SubTotalEarning + monthFinance.SubTotalExpense; 
            
            return monthFinance;
        }
    }
}