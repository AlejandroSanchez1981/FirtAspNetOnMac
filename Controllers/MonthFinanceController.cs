using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstaspnet.Data.DbContext.Interfaces;
using firstaspnet.Models;
using Microsoft.AspNet.Mvc;

namespace firtaspnet.Controllers
{
    public class MonthFinanceController : Controller
    {
        private readonly IMonthFinanceConfigurationsPersister monthFinanceConfPer;
        
        public MonthFinanceController(IMonthFinanceConfigurationsPersister monthFinanceConfPer)
        {
            this.monthFinanceConfPer = monthFinanceConfPer;
        }
        
        public ActionResult Index()
        {
            return View("Index");
        }
        
        public bool Save(MonthFinanceModel model)
        {
            //if(!model.Name.Any())
            //    return false;
            
            return true;
        }
    }
}