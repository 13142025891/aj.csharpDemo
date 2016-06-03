using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMvc
{
    public class ControllerBase : IController
    {
        protected IActionInvoker ActionInvoker { get; set; }

        public ControllerBase()
        {
            this.ActionInvoker =new  ControllerActionInvoker();
        }
        public void Execute(RequextContext requestContext)
        {
            ControllerContext c = new ControllerContext {RequestContext=requestContext, Controller=this};
            string actionName = requestContext.RouteData.ActionName;
            this.ActionInvoker.InvokerAction(c,actionName);
        }
    }
}