using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Mvc.Repository;

namespace Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // ControllerBuilder.Current.SetControllerFactory();
          
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityContainer container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            UnityControllerFactory controllerfactory = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerfactory);
        }
    }
}
