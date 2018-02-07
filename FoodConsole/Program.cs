using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Models;
using Common;
using Common.Redis;
using EntityFrameWorkDal;

namespace FoodConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new WeatherUpdaeCon().CtrlHistoricalWeather();
        }



    }

}
