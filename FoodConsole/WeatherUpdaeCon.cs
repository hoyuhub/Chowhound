using System;
using Common;
using Common.Redis;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Text;
using Models;
using EntityFrameWorkDal;
using Newtonsoft.Json;

namespace FoodConsole
{

    public class WeatherUpdaeCon : Common.Redis.RedisCommon
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

        //1.首先获取redis中记录的所有天气Key(获得天气历史的对应信息)
        //2.将所有数据都整理成对应信息，保存到MSSQL中
        public void CtrlHistoricalWeather()
        {
            var keys = GetConn().GetServer(GetConn().GetEndPoints()[0]).Keys(0, "*");
            List<HistoricalWeather> ListHis = new List<HistoricalWeather>();
            foreach (var item in keys)
            {
                foreach (var v in GetConn().GetDatabase().HashGetAll(item))
                {
                    HistoricalWeather his = new HistoricalWeather();
                    his.id = Guid.NewGuid().ToString();
                    his.CityId = item;
                    his.CurrentDate = Convert.ToDateTime(v.Name);
                    Dictionary<string, List<Dictionary<string, object>>> dic = new Dictionary<string, List<Dictionary<string, object>>>();
                    dic = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, object>>>>(v.Value);
                    List<Dictionary<string, object>> listDicResults = dic["results"];
                    List< Dictionary<string ,string>> dicDaily=new List< Dictionary<string, string>>();
                    dicDaily=JsonConvert.DeserializeObject<List< Dictionary<string,string>>>( listDicResults[0]["daily"].ToString());
                }
            }
        }

    }
}