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
using log4net;
namespace FoodWeb.Controllers
{
    public class WeatherController : BaseController
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
        public string LoadWeather()
        {
            try
            {
                List<XCity> list = new Address().GetXCity("中国地级市");
                new Weather().WeatherUpdate(list);
            }
            catch (Exception e)
            {
                throw e;
            }
            return string.Empty;
        }
    }
}