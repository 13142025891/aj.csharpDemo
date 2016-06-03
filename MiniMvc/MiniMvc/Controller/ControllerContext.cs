using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMvc
{
    public class ControllerContext
    {
        public ControllerBase Controller { get; set; }
        public RequextContext RequestContext { get; set; }
    }
}