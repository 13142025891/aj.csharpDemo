using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Compilation;

namespace MiniMvc
{
    public class DefaultControllerFactory : IControllerFactory
    {
        private static List<Type> controllerTypes = new List<Type>();
        static DefaultControllerFactory()
        {
         
            foreach (Assembly ass in BuildManager.GetReferencedAssemblies())
            {
                foreach (Type type in ass.GetTypes().Where(t => typeof(IController).IsAssignableFrom(t)))
                {
                    controllerTypes.Add(type);
                }
            }
        }
        public IController CreateController(RequextContext requestContext, string controllerName)
        {
            string typeName = controllerName + "Controller";
            Type controllerType = controllerTypes.FirstOrDefault(o=>string.Compare(typeName,o.Name,true)==0);
            if (null == controllerType)
            {
                return null;
            }
            return (IController)Activator.CreateInstance(controllerType);
        }
    }
}