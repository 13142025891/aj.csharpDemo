using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
namespace Mvc
{
    public class UnityControllerFactory:DefaultControllerFactory
    {
        public IUnityContainer _container { get; private set; }
        public UnityControllerFactory(IUnityContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (null == controllerType)
            {
                return null;
            }
            return (IController)_container.Resolve(controllerType);
        }

    }
}