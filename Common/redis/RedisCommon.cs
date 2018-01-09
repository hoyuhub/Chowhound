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

        public string [] GetAllCityName()
        {
            return GetConn().GetDatabase().SetMembers("CityName").ToStringArray();
        }
    }
}