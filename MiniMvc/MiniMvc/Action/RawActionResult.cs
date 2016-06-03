using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace MiniMvc
{
    public class RawActionResult : ActionResult
    {
        public Action<TextWriter> CallBack { get; private set; }
        public RawActionResult(Action<TextWriter> callBack)
        {
            this.CallBack = callBack;
        }
        public override void ExecuteResult(ControllerContext controllerContext)
        {
            this.CallBack(controllerContext.RequestContext.HttpContext.Response.Output);
        }
    }
}