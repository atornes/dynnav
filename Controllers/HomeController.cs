using Microsoft.AspNet.Mvc;

namespace DynNav.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}