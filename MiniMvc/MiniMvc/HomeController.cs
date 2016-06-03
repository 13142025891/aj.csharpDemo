using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace MiniMvc
{
    public class HomeController:ControllerBase
    {
        public ActionResult Index(SimpleModel model)
        {
            //RouteData
            Action<TextWriter> text = write => {
                write.Write(string.Format("Controller:{0} <br/> action:{1}<br/><br/>",model.Controller,model.Action));
                write.Write(string.Format("Foo:{0} <br/> Bar:{1}<br/> Baz<br/>", model.Foo, model.Bar,model.Baz));

            };
            return new RawActionResult(text);
        }
    }
}