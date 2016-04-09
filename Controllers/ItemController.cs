using firtaspnet.Interfaces.ioc;
using firtaspnet.Models;
using Microsoft.AspNet.Mvc;
using firstaspnet.Data.Entities;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using Microsoft.AspNet.Http.Internal;
using firstaspnet.Models;

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
            var model = new ItemModel();
            //var model = item.GiveItem().ToItemModel();
            return View(model);
        }
        
        public ActionResult Save(FormCollection form)
        {
            if(form == null)
                return View("Error");
           
             if(form["Name"] == "")
                return View("Error");
            
            
            
            return View("Index");
        }
        
        //public ActionResult Save()
        //{
            //how save on file in azure from here;
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            //    "DefaultEndpointsProtocol=https;AccountName=sliderproductos;AccountKey=9Ai9hSGBcEwT6EMt14UbyiMcGYOPdj/7Oa2W6LZ+c8JDRmeq94pEWi/fz62Lx+bEENg0hyKMY+eufYkBXMDhvg==");
                
            //CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            
            // Retrieve a reference to a container.
            //CloudBlobContainer container = blobClient.GetContainerReference("finanzas");
            
            // Retrieve reference to a blob named "myblob".
            //CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");
            
            // Create or overwrite the "myblob" blob with contents from a local file.
            /*using (var fileStream = System.IO.File.OpenRead(@"path/myfile2.txt"))
            {
                blockBlob.UploadFromStream(fileStream);
            }
            */
        //    return RedirectToAction("Index");
        //}
        
        
    }
}

/*
Multiple constructors accepting all given argument 
types have been found in type 'firtaspnet.Controllers.ItemController'. 
There should only be one applicable constructor.
*/