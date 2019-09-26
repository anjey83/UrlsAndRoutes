using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlsAndRoutes.Models
{
    public class Result
    {
        public string Controller { get; set; }
        public string Action { get; set; }

        //other details about the request produced by the routing system
        public IDictionary<string, object> Data { get; } = new Dictionary<string, object>();
    }
}
