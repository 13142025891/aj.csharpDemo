using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMvc
{
    public class BinderBuilder
    {
        private Func<IModelBinder> binderThunk;
       
        public static BinderBuilder Current { get; private set; }
        static BinderBuilder()
        {
            Current = new BinderBuilder();
        }
        public IModelBinder GetModelBinder()
        {
            return binderThunk();
        }

        public void SetModelBinder(IModelBinder modelBinder)
        {
            this.binderThunk =()=> modelBinder;
           
        }
    }
}