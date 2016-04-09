using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstaspnet.Models;
using Microsoft.AspNet.Mvc;

namespace firtaspnet.Controllers
{
    public class MonthFinanceController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
        
        public bool Save(MonthFinanceModel model)
        {
            if(!model.Name.Any())
                return false;
            
            return true;
        }
    }
}