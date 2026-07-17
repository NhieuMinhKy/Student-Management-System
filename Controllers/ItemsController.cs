using Microsoft.AspNetCore.Mvc;
using ASP.NET_CORE_Tutorial.Models;

namespace ASP.NET_CORE_Tutorial.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item() { Name="keyboard"};
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }
    }
}
