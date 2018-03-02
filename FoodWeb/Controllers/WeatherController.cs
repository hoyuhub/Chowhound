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
         protected override void GetLog()
        {
            log =LogManager.GetLogger(Startup.repository.Name, typeof(WeatherController));
        }
        public bool UpdateHistoryWeatherToMssql()
        {
            RedisCommon redis = new RedisCommon();
            try
            {
                redis.CtrlHistoricalWeather();
            }
            catch (Exception e)
            {
                log.ErrorFormat("MSSQL同步Redis发生异常:{0}",e);
                return false;
            }
            return true;
        }
        public bool LoadWeather()
        {
            try
            {
                List<XCity> list = new Address().GetXCity("中国地级市");
                new Weather().WeatherUpdate(list);
                return true;
            }
            catch (Exception e)
            {
                log.ErrorFormat("下载心知天气发生异常:{0}",e);
                return false;
            }
        }
    }
}