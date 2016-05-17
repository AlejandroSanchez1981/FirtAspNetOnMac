using firstaspnet.Interfaces.ioc;
using firstaspnet.Models;
using Microsoft.AspNet.Mvc;
using firstaspnet.Data.Entities;
using Microsoft.AspNet.Http.Internal;


namespace firstaspnet.Controllers
{
    public class ItemController : Controller
    {
        public IRepository<Item> item;
         
        public ItemController(IRepository<Item> item)
        {
            this.item = item;
        }
       
        public ActionResult Create()
        {
            var model = new ItemModel();
            //var itemChild = new ItemChildModel{ Name="Damian" };
            //model.ListItemChildModel.Add(itemChild);
            
            return RedirectToAction("Index", model);
        }
       
        public ActionResult Index()
        {
            // var model = new ItemModel();
            // var itemChild = new ItemChildModel{ Name="Damian" };
            // model.ListItemChildModel.Add(itemChild);
            //var model = item.GiveItem().ToItemModel();
            return View();
        }
        
        
        public ActionResult Save(FormCollection form)
        {
            if(form == null)
                return View("Error");
           
             if(form["Name"] == "")
                return View("Error");
            
            return View("Index");
        }
    }
}

/*
Multiple constructors accepting all given argument 
types have been found in type 'firstaspnet.Controllers.ItemController'. 
There should only be one applicable constructor.
*/