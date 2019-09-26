using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class CustomerController : Controller
    {
        [Route("[controller]/MyAction")]
        // Route                Description
        // /Customer/List       This URL targets the List action method. 
        // /Customer/MyAction   This URL targets the Index action method.

        //[Route( "myroute" )]
        //// Route                Description
        //// /Customer/List       This URL targets the List action method, relying on the default route in the Startup.cs file. 
        //// /myroute             This URL targets the Index action method.
        public ViewResult Index( ) => View( "Result", new Result
        {
            Controller = nameof( CustomerController ),
            Action = nameof( Index )
        } );

        public ViewResult List( string id )
        {
            Result r = new Result
            {
                Controller = nameof( HomeController ),
                Action = nameof( List ),
            };

            r.Data["Id"] = id ?? "<no value>";
            r.Data["catchall"] = RouteData.Values["catchall"];

            return View( "Result", r );
        }
    }
}