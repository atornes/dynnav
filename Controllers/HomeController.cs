using dynnav.Controllers;
using Microsoft.AspNet.Mvc;

namespace DynNav.Controllers
{
    public class HomeController : Controller
    {
        private const string FRAGMENT = "_escaped_fragment_";

        public IActionResult Index(string _escaped_fragment_)
        {
            if (!string.IsNullOrEmpty(_escaped_fragment_))
                return GetSnapshot(_escaped_fragment_);

            return View();
        }

        public ContentResult GetSnapshot(string path)
        {
            var route = Routes.Get(path);

            var url = Request.Scheme + "://" + Request.Host.ToString() + "/#!" + path;

            var snapshot = Snapshot.Get(url);

            return Content(snapshot, "text/html");
        }
    }
}