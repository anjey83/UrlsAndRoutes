using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    [Route("app/[controller]/actions/[action]/{id:weekday?}")]
    // Route                                        Description
    // app/customer/actions/index                   This URL targets the Index action method.
    // app/customer/actions/index/myid              This URL targets the Index action method with the optional id segment set to myid. 
    // app/customer/actions/list                    This URL targets the List action method. 
    // app/customer/actions/list/myid               This URL targets the List action method with the optional id segment set to myid.

    public class CustomerController : Controller
    {
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