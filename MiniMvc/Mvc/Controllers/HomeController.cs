using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Repository;
using Microsoft.Practices.Unity;
namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public IEmployeeRepository Repository { get; set; }
        // GET: Home
        public ActionResult GetAll()
        {
           var list= Repository.GetEmployeeAll();

            return View("employeeList",list);
        }

        public ActionResult GetById(string id)
        {
            var model = Repository.GetEmployeeAll(id).FirstOrDefault();
            if (null == model)
            {
                return HttpNotFound();
            }
            return View("GetById", model);
        }


    }
}