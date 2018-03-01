using System;
using StackExchange.Redis;
using System.Collections.Generic;
using Models;
using Newtonsoft.Json;
using EntityFrameWorkDal;
using log4net;
namespace FoodWeb.Common
{
    public class RedisCommon
    {
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(RedisCommon));
        private static ConnectionMultiplexer redis;

        public ConnectionMultiplexer GetConn()
        {
            if (redis == null)
            {
                redis = ConnectionMultiplexer.Connect("169.254.244.73:6379");
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

        //以hash方式存储天气信息，filed为当天日期，key是当前天，value是查到的json数据
        public void WeatherHashSet(Dictionary<string, string> dic)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd");
            foreach (var str in dic.Keys)
            {
                GetConn().GetDatabase().HashSet("weather:" + str, time, dic[str]);
            }
        }

        //以hash方式存储天气信息，filed为当天日期，key是当前天，value是查到的json数据
        public void WeatherHashSet(string filedName, string value)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd");
            GetConn().GetDatabase().HashSet("weather:" + filedName, time, value);
        }

        //记录调用接口时间
        public void SetXinZhiApiCallTime(DateTime time)
        {
            GetConn().GetDatabase().SetAdd("XinZhiApiCallTime", time.ToString());
        }

        //根据心知天气API文档，一个小时只能调取四百次
        //做每小时只能调用一次判断，若返回true则可以继续调用，否则不可以调用
        public bool CheckXinZhiApiCallTime()
        {
            if (GetConn().GetDatabase().KeyExists("XinZhiApiCallTime"))
            {

                string time = GetConn().GetDatabase().StringGet("XinZhiApiCallTime");
                DateTime dt = Convert.ToDateTime(time);
                if (dt.AddHours(1).CompareTo(DateTime.Now) > 0)
                {
                    return false;
                }
                else { return true; }
            }
            else { return true; }

        }

        //每次调用接口时都将调用次数累加
        public void IncrXinZhiApiCallCount(DateTime time)
        {
            GetConn().GetDatabase().HashIncrement("SetXinZhiApiCallCount", time.ToString(), 1);
        }
        //1.首先获取redis中记录的所有天气Key(获得天气历史的对应信息)
        //2.将所有数据都整理成对应信息，保存到MSSQL中
        public void CtrlHistoricalWeather()
        {
            var keys = GetConn().GetServer(GetConn().GetEndPoints()[0]).Keys(0, "weather:*");
            List<HistoricalWeather> listHis = new List<HistoricalWeather>();
            try
            {


                foreach (var item in keys)
                {
                    foreach (var v in GetConn().GetDatabase().HashGetAll(item))
                    {

                        Dictionary<string, List<Dictionary<string, object>>> dic = new Dictionary<string, List<Dictionary<string, object>>>();
                        dic = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, object>>>>(v.Value);

                        List<Dictionary<string, object>> listDicResults = dic["results"];
                        List<Dictionary<string, string>> dicDaily = new List<Dictionary<string, string>>();


                        dicDaily = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(listDicResults[0]["daily"].ToString());

                        foreach (var s in dicDaily)
                        {
                            HistoricalWeather his = new HistoricalWeather();
                            his.id = Guid.NewGuid().ToString();
                            his.CityId = item;
                            his.CurrentDate = Convert.ToDateTime(v.Name);
                            his.Date = Convert.ToDateTime(s["date"]);
                            his.TextDay = s["text_day"];
                            his.CodeDay = Convert.ToInt32(s["code_day"]);
                            his.TextNight = s["text_night"];
                            his.CodeNight = Convert.ToInt32(s["code_night"]);
                            his.High = Convert.ToInt32(s["high"]);
                            his.Low = Convert.ToInt32(s["low"]);
                            his.Precip = s["precip"];
                            his.WindDirection = s["wind_direction"];
                            his.WindDirectionDegree = s["wind_direction_degree"];
                            his.WindSpeed = Convert.ToInt32(s["wind_speed"]);
                            his.WindScale = Convert.ToInt32(s["wind_scale"]);

                            listHis.Add(his);
                        }
                    }

                }
                HistoricalWeathersDal hisDal = new HistoricalWeathersDal();
                hisDal.Add(listHis);
            }
            catch (Exception e)
            {
               log.ErrorFormat("MSSQL同步Redis发生异常:{0}",e);
            }
        }
    }
}