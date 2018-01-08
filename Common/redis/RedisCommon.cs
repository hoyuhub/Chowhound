using System;
using StackExchange.Redis;
using System.Collections.Generic;


namespace Common.Redis
{
    public class RedisCommon
    {
        private static ConnectionMultiplexer redis;

        private static ConnectionMultiplexer GetConn()
        {
            if (redis == null || redis.IsConnected)
            {
                redis = ConnectionMultiplexer.Connect("localhost");
            }
            return redis;
        }

        public string GetWeather(string cityName)
        {
            return GetConn().GetDatabase().HashGet(cityName, DateTime.Now.ToString("yyyy:MM:dd")).ToString();
        }

        //访问心知天气，获取最新数据，保存到redis中
        public void UpdateWeather()
        {
            RedisValue[] valueArray = GetConn().GetDatabase().SetMembers("CityName");
            if (valueArray.Length != 345)
            {
                // Address address = new Address();
                // List<SCity> listCity = address.City();
                //listCity.ForEach(d => GetConn().GetDatabase().SetAdd("CityName", d.CityName.Substring(0,d.CityName.Length-1)));
            }
            Weather weather = new Weather();
            foreach (var i in valueArray.ToStringArray())
            {
                weather.GetDaily(i);
            }

        }
    }
}