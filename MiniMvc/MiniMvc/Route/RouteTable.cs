using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMvc
{
    public class RouteTable
    {
        public static RouteDictionary Routes { get; set; }
        static RouteTable()
        {
            Routes = new RouteDictionary();
        }
    }
    public class RouteDictionary : Dictionary<string, RouteBase>
    {
        public RouteData GetRouteData(HttpContextBase httpContext)
        {
            foreach (var route in this.Values)
            {
                RouteData routeData = route.GetRouteData(httpContext);
                if (null != routeData)
                {
                    return routeData;
                }
            }
            return null;
        }
    }
}