using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace MiniMvc
{
   public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(RequextContext requextContext);

    }
}
