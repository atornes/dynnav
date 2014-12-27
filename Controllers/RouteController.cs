using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using DynNav.Models;

namespace DynNav.Controllers
{

    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        static readonly List<Route> _routes = new List<Route>()
        {
            new Route { Path = "/", ViewPath = "/app/views/home.html", ControllerPath = "" },
            new Route { Path = "/404", ViewPath = "/app/views/404.html", ControllerPath = "" },
            new Route { Path = "/about", ViewPath = "/app/views/about.html", ControllerPath = "" },
            new Route { Path = "/contact", ViewPath = "/app/views/contact.html", ControllerPath = "" },
            new Route { Path = "/test", ViewPath = "/app/views/test.html", ControllerPath = "" },
        };

        [HttpGet(Name = "GetRouteByPath")]
        public IActionResult GetRoute(string path)
        {
            //No path, return all
            if (string.IsNullOrEmpty(path))
                return new ObjectResult(_routes);

            //Find route
            var route = _routes.FirstOrDefault(x => x.Path == path);

            //Not found, 404
            if (route == null)
                return HttpNotFound();

            //Return route
            return new ObjectResult(route);
        }

        [HttpPost]
        public void CreateRoute([FromBody] Route route)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                _routes.Add(route);

                string url = Url.RouteUrl("GetRouteByPath", new { path = route.Path }, 
                    Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{path}")]
        public IActionResult DeleteRoute(string path)
        {
            var route = _routes.FirstOrDefault(x => x.Path == path);
            if (route == null)
            {
                return HttpNotFound();
            }

            _routes.Remove(route);
            
            return new HttpStatusCodeResult(204); // 201 No Content
        }
    }
}