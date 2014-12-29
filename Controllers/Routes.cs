using DynNav.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dynnav.Controllers
{
    public static class Routes
    {
        static readonly List<Route> _routes = new List<Route>()
        {
            new Route { Path = "/", ViewPath = "/app/views/home.html", ControllerPath = "" },
            new Route { Path = "/404", ViewPath = "/app/views/404.html", ControllerPath = "" },
            new Route { Path = "/about", ViewPath = "/app/views/about.html", ControllerPath = "" },
            new Route { Path = "/contact", ViewPath = "/app/views/contact.html", ControllerPath = "" },
            new Route { Path = "/test", ViewPath = "/app/views/test.html", ControllerPath = "" },
        };

        public static List<Route> All { get { return _routes; } }

        public static Route Get(string path)
        {
            return _routes.FirstOrDefault(x => x.Path == path);
        }
    }
}