using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodWeb.Models;
using Models;
using EntityFrameWorkDal;
using FoodWeb.Common;
namespace FoodWeb.Controllers
{
    public class WeatherController : Controller
    {

        public bool UpdateHistoryWeatherToMssql()
        {
            RedisCommon redis = new RedisCommon();
            try
            {
                redis.CtrlHistoricalWeather();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
            return true;
        }
    }
}