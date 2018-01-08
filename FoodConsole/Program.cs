using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Models;
using Common;
using Common.Redis;

namespace FoodConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Test();
        }

        public static void Test()
        {
            string hKey = DateTime.Now.ToString("yyyy-MM-dd");
            string cityName = string.Format("beijing_{0}", hKey);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("test1", "123");
            dictionary.Add("test2", "234");
           // RedisClient redis = new RedisClient();
            //redis.HGet("beijing_2018-01-08");
        }

    }

}
