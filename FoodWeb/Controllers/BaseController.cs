using System;
using Microsoft.AspNetCore.Mvc;
using log4net;
namespace FoodWeb.Controllers
{
    public class BaseController : Controller
    {
        protected ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(BaseController));
    }

}