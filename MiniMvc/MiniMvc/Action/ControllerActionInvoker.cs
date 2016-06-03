using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
namespace MiniMvc
{
    public class ControllerActionInvoker : IActionInvoker
    {
        public IModelBinder ModelBinder { get; private set; }
        public ControllerActionInvoker()
        {
            ModelBinder = BinderBuilder.Current.GetModelBinder();
        }
        public void InvokerAction(ControllerContext controllerContext, string actionName)
        {
            MethodInfo method = controllerContext.Controller.GetType().GetTypeInfo().DeclaredMethods.FirstOrDefault(o=>string.Compare(o.Name,actionName,true)==0);
            List<object> paramenters = new List<object>();
            foreach (ParameterInfo p in method.GetParameters())
            {
                paramenters.Add(ModelBinder.BindModel(controllerContext,p.Name,p.ParameterType));
            }
            ActionExecutor executor = new ActionExecutor(method);
            ActionResult result = (ActionResult)executor.Execute(controllerContext.Controller,paramenters.ToArray());
            result.ExecuteResult(controllerContext);
        }
    }
}