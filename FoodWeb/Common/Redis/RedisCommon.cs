using System;
using StackExchange.Redis;
using System.Collections.Generic;
namespace FoodWeb.Common
{
    public class RedisCommon
    {
        private static ConnectionMultiplexer redis;

        public ConnectionMultiplexer GetConn()
        {
            if (redis == null)
            {
                redis=ConnectionMultiplexer.Connect("169.254.244.73:6379");
            }
            return redis;
        }

        public string GetWeather(string cityName)
        {
            return GetConn().GetDatabase().HashGet(cityName, DateTime.Now.ToString("yyyy:MM:dd")).ToString();
        }

        public string[] GetAllCityName()
        {
            return GetConn().GetDatabase().SetMembers("CityName").ToStringArray();
        }

        //以hash方式存储天气信息，filed为当天日期，value是查到的json数据
        public void WeatherHashSet(Dictionary<string, string> dic)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd");
            foreach (var str in dic.Keys)
            {
                GetConn().GetDatabase().HashSet("weather:" + str, time, dic[str]);
            }
        }
    }
}