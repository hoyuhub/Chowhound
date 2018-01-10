using System;
using Common;
using Common.Redis;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Text;
using Models;
using EntityFrameWorkDal;
public class WeatherUpdaeCon
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


    public void test()
    {
        string filePath = "e:/桌面/exceltest.txt";
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            List<string> list = new List<string>();
            using (var redar = new StreamReader(stream, Encoding.UTF8))
            {

                string line;
                while ((line = redar.ReadLine()) != null)
                {
                    list.Add(line);
                }

                List<XCity> listCity = new List<XCity>();

                list.ForEach(d =>
                {
                    string[] s = d.Split("\t");
                    listCity.Add(new XCity(s[0], s[1], s[2], s[5], s[6], s[7], s[8], s[9], s[10]));
                });
                Address address = new Address();
                int result = address.AddCity(listCity);
                Console.WriteLine(result);
            }

        }
    }

}