using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc.Models;
namespace Mvc.Repository
{
   public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployeeAll(string id="");
     }
}
