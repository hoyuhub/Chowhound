using System;
using Microsoft.AspNetCore.Mvc;
using log4net;
namespace FoodWeb.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ILog log;
        // = LogManager.GetLogger(Startup.repository.Name, typeof(BaseController));
        public BaseController()
        {
            GetLog();
        }
       
        protected virtual void GetLog()
        {
            log=LogManager.GetLogger(Startup.repository.Name,GetType());
        }

       
    }

}