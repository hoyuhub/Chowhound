using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodWeb.Models;
using Common;

namespace FoodWeb.Controllers
{
    public class TestController:Controller
    {
         public IActionResult Index()
        {
            Dictionary<string ,string > dic=new Dictionary<string ,string>();
            dic.Add("123","345")
            return View(dic);
        }

        public string test()
        {
            
        }
    }
}