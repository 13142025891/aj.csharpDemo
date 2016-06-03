using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Models;

namespace Mvc.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> employees;
        static EmployeeRepository()
        {
            employees = new List<Employee>();
            employees.Add(new Employee("001","wupan","男","技术部"));
            employees.Add(new Employee("002", "戴娟", "女", "文职部"));
            employees.Add(new Employee("003", "阿拉蕾", "女", "篮球部"));
            employees.Add(new Employee("004", "刀疤威", "男", "足球部"));
        }
        public  IEnumerable<Employee> GetEmployeeAll(string id = "")
        {
            return employees.Where(o => o.Id == id || string.IsNullOrEmpty(id));
        }
    }
}