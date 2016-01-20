using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace firtaspnet.Controllers
{
    public class Item : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}