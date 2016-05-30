using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstaspnet.Data.DbContext;
using firstaspnet.Data.DbContext.Interfaces;
using firstaspnet.Data.Entities;
using firstaspnet.Entities;
using firstaspnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstaspnet.Controllers
{
    public class MonthFinanceController : Controller
    {
        private readonly IFinanceConfigurationPersister monthFinanceConfPer;
        
        public MonthFinanceController(IFinanceConfigurationPersister monthFinanceConfPer)
        {
            this.monthFinanceConfPer = monthFinanceConfPer;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ListCurrentMonth()
        {
            return PartialView("partials/listcurrentmonth");
        } 
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<ItemModel> GetEarning()
        {
             return new List<ItemModel>{
                new ItemModel{Name = "Salary", HowMuch = 5000}
            };
        }
        
        [HttpPost]
        public bool SaveMonthFinance([FromBody] MonthFinanceModel monthFinances)
        {
            //var entity = monthFinances.ToModelToEntity();
            
            var entityExpense = new Expense {
                ListItemsExpense = monthFinances.Expense.ListItemsExpenseModel.Select(x=>x.ModelToEntity())
            };
            
            var entityEarning = new Earning
            {
                ListItemsEarning = monthFinances.Earning.ListItemsEarningModel.Select(x=>x.ModelToEntity())
            };
            
            var entity = new MonthFinance
            {
               Name = monthFinances.Name,
               MonthExpensive = entityExpense,
               MonthEarning = entityEarning 
            };
            
            entity.Id = Guid.Parse("efede5a3-0b4c-4d41-a054-55d1b97ae35e");
            monthFinanceConfPer.Persist(entity);
            
            return true;
        }
        
        //GetDocument
        [HttpGet]
        public async Task<MonthFinanceModel> GetDocument()
        {
            
            var model = new MonthFinanceModel();
            var entity = (await monthFinanceConfPer.Get()).ToArray();
            
            
            //todo: remove guid hardcore
            
            model = entity.Where(x => x.Id.Equals(Guid.Parse("efede5a3-0b4c-4d41-a054-55d1b97ae35e"))).Select(x => x.ToMonthFinanceModel()).FirstOrDefault()
									?? entity.Where(x => x.IsDefault).Select(x => x.ToMonthFinanceModel()).FirstOrDefault();
            
            return model;
        }
        
        
        
        // public bool Save(MonthFinanceModel model)
        // {
        //     model = new MonthFinanceModel();
            
        //     var earningModel = new EarningModel {ListItemsEarningModel = new List<ItemModel>{
        //         new ItemModel{Name = "Salary", HowMuch = 5000}
        //     }};
            
        //     var expenseModel = new ExpensesModel{ListItemsExpenseModel = new List<ItemModel>{
        //       new ItemModel {Name = "Rent House Dublin", HowMuch = 2500}  
        //     }};
            
        //     var monthFinanceEntity = new MonthFinanceModel{
        //         ExpenseModel = expenseModel,
        //         EarningModel = earningModel,
        //         Saving = 1000
        //     };
            
        //     var entity = monthFinanceEntity.ToModelToEntity();
            
        //     entity.SubTotalEarning = 5000;
        //     entity.SubTotalExpense = 2500;
        //     entity.Id = Guid.NewGuid();
        //     //entity.Id = Guid.Parse("efede5a3-0b4c-4d41-a054-55d1b97ae35e");
            
            
        //     monthFinanceConfPer.Persist(entity);
            
        //     return true;
        // }
    }
}