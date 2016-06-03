using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Mvc.Models
{
    public class Employee
    {
        [Display(Name ="Id")]
        public string Id { get; private set; }
        [Display(Name = "姓名")]
        public string Name { get; private set; }
        [Display(Name = "性别")]
        public string Gender { get; private set; }
        [Display(Name = "部门")]
        public string Deparment { get; private set; }
      
        public Employee(string id,string name,string gender,string deparment)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.Deparment = deparment;
        }
    }
}