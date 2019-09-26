using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index( ) => View( "Result", new Result
        {
            Controller = nameof( HomeController ),
            Action = nameof( Index )
        } );

        //value from third segment is assigned to the custom variable 'id'
        //MVC compares the list of segment variables with the list of action method parameters and, if the names match, passes the values from the URL to the method
        //parameter automatically converts to the defined type in action
        public ViewResult CustomVariable( string id)
        {
            Result r = new Result { Controller = nameof( HomeController ),
                Action = nameof( CustomVariable ), };
            r.Data["Id"] = id;

            return View( "Result", r ); }
    }
}