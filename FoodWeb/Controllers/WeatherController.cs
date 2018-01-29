using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodWeb.Models;
using Common;
using Models;
using Common.Redis;
using EntityFrameWorkDal;

namespace FoodWeb.Controllers
{
    public class   WeatherController:Controller
    {
        
         //更新天气    
    public void WeatherUpdate()
    {
        Weather weather = new Weather();
        List<XCity> list = new Address().GetXCity("中国地级市");
        RedisCommon redis = new RedisCommon();
        Dictionary<string, string> dic = new Dictionary<string, string>();
        list.ForEach(d =>
        {
            dic.Add(d.Id, weather.GetDaily(d.Id));
            Console.WriteLine(d.EName);
        });
        redis.WeatherHashSet(dic);

    }
    }
}