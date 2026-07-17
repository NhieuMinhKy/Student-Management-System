using Microsoft.AspNetCore.Mvc;
namespace ASP.NET_CORE_Tutorial.Controllers
{
    public class AccountController : Controller
    {
       public IActionResult Login()
        {
            return View();
        }

    }
}
