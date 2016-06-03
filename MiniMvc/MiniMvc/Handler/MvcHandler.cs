using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMvc
{
    public class MvcHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public RequextContext requestContext { get; set; }
        public MvcHandler(RequextContext requestContext)
        {
            this.requestContext = requestContext;
        }
        public void ProcessRequest(HttpContext context)
        {
            string controllerName = requestContext.RouteData.Controller;
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
            IController controller = factory.CreateController(requestContext, controllerName);
            controller.Execute(requestContext);
       }
    }
}