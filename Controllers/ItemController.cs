using firtaspnet.interfaces.ioc;
using firtaspnet.Models;
using Microsoft.AspNet.Mvc;
//using firstaspnet.Data.Entities;
using firtaspnet.Data.DbContext.Json

namespace firtaspnet.Controllers
{
    public class ItemController : Controller
    {
        public IRepository<Item> item;
         
        public ItemController(IRepository<Item> item)
        {
            this.item = item;
        }
        
        public ActionResult Index()
        {
            var model = item.GiveItem().ToItemModel();
            return View(model);
        }
        
    }
}

/*
Multiple constructors accepting all given argument 
types have been found in type 'firtaspnet.Controllers.ItemController'. 
There should only be one applicable constructor.
*/