using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using DynNav;
using DynNav.Models;
using dynnav.Controllers;

namespace DynNav.Controllers
{

    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        [HttpGet(Name = "GetRouteByPath")]
        public IActionResult GetRoute(string path)
        {
            //No path, return all
            if (string.IsNullOrEmpty(path))
                return new ObjectResult(Routes.All);

            //Find route
            var route = Routes.Get(path);

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
                Routes.All.Add(route);

                string url = Url.RouteUrl("GetRouteByPath", new { path = route.Path }, 
                    Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{path}")]
        public IActionResult DeleteRoute(string path)
        {
            var route = Routes.Get(path);

            if (route == null)
            {
                return HttpNotFound();
            }

            Routes.All.Remove(route);
            
            return new HttpStatusCodeResult(204); // 201 No Content
        }
    }
}