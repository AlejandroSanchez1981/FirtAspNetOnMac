using Microsoft.AspNet.Mvc;
using firtaspnet.Data.Interface;
using firtaspnet.Models;
using System.Linq;

namespace firtaspnet.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        
        public IActionResult Index()
        {
            var items = _itemRepository.ListAll();
            if (!items.Any())
            {
                _itemRepository.Add(new Item("Hello Word!"));
                items = _itemRepository.ListAll();
            }
            return View(items);
        }
    }
}