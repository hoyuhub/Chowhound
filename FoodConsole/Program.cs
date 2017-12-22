using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Models;

namespace FoodConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
             List<SCity> listCity= new Address().City(1);
             listCity.ForEach(d=>Console.WriteLine(d.CityName));

        }
    }

    
}
