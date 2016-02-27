using firtaspnet.Models;
using Microsoft.AspNet.Mvc;

namespace firtaspnet.Controllers
{
    public class ItemController : Controller
    {
        public interfaces.ioc.IRepository item;
         
        public ItemController(interfaces.ioc.IRepository item)
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