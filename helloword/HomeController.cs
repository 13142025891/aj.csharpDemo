using Microsoft.AspNetCore.Mvc;
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public string Index() 
        {
           return "���� ��Hello Word ";          
        }
  }