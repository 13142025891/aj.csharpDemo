using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMvc
{
    public class ControllerBuilder
    {
        private Func<IControllerFactory> factoryThunk;

        public static ControllerBuilder Current { get;private set; }
        static ControllerBuilder()
        {
            Current = new ControllerBuilder();
        }

        public IControllerFactory GetControllerFactory()
        {
            return factoryThunk();
        }


        public void SetControllerFactory(IControllerFactory ControllerFactory)
        {
            this.factoryThunk = () => ControllerFactory;
        }
    }
}