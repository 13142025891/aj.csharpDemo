using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMvc
{
    public class Route:RouteBase
    {
        public IRouteHandler RouteHandler { get; set; }
        public string Url { get; set; }
        public IDictionary<string, object> DataTokens { get; set; }
        public Route()
        {
            RouteHandler = new MvcRouteHandler();
            this.DataTokens = new Dictionary<string, object>();
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            IDictionary<string, object> variables;
            if (Match(httpContext.Request.AppRelativeCurrentExecutionFilePath.Substring(2), out variables))
            {
                RouteData routeData = new RouteData();
                foreach (var item in variables)
                {
                    routeData.Values.Add(item.Key,item.Value);
                }
                foreach (var item in DataTokens)
                {
                    routeData.DataTokens.Add(item.Key, item.Value);
                }
                routeData.RouteHandler = RouteHandler;
                return routeData;
            }
            return null;
        }
        protected bool Match(string requestUrl, out IDictionary<string, object> variables)
        {
            variables = new Dictionary<string, object>();
            var strArr1 = requestUrl.Split('/');
            var strArr2 = this.Url.Split('/');
            if (strArr1.Length != strArr2.Length)
            {
                return false;
            }
            for (var i = 0; i < strArr2.Length; i++)
            {
                if (strArr2[i].StartsWith("{") && strArr2[i].EndsWith("}"))
                {
                    variables.Add(strArr2[i].Trim("{}".ToCharArray()), strArr1[i]);
                }
                else
                {
                    if (string.Compare(strArr1[i], strArr2[i], true) != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}