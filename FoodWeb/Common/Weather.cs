using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Models;
using log4net;
namespace FoodWeb.Common
{
    public class Weather
    {
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(RedisCommon));

        //心知天气API key
        private static string apiKey = "tvwzmnqbgga053xr";
        //心知天气用户ID
        //private static string userId = "UD7AD56A5E";
        //心知天气接口路径
        private static string s_url = "https://api.seniverse.com/v3/weather/";
        //创建静态客户端对象
        private static WebClient client = new WebClient();

        //获取天气实况
        public string GetNowWeather(string cityName)
        {
            string url = string.Format("{0}now.json?key={1}&location={2}&language=zh-Hans", s_url, apiKey, cityName);
            return GetRespons(url);
        }

        //逐日天气预报和昨日天气
        public string GetDaily(string cityName)
        {
            string url = string.Format("{0}daily.json?key={1}&location={2}&language=zh-Hans&unit=c&start=-1&days=5", s_url, apiKey, cityName);
            return GetRespons(url);
        }

        //获取生活指数
        public string GetLifeSuggestion(string cityName)
        {
            string url = string.Format("{0}life/suggestion.json?key={1}&language=zh-Hans&location={2}", s_url, apiKey, cityName);
            return GetRespons(url);
        }

        //根绝接口路径访问心知天气
        public string GetRespons(string url)
        {
            byte[] bResponse = client.DownloadData(url);
            string strResponse = Encoding.UTF8.GetString(bResponse);
            return strResponse;
        }

        //更新天气    
        public void WeatherUpdate(List<XCity> list)
        {

            int count = 0;
            RedisCommon redis = new RedisCommon();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            bool terminationRequest = false;
            do
            {
                try
                {

                    list.ForEach(d =>
                    {
                        string result = GetDaily(d.Id);
                        redis.WeatherHashSet(d.Id, result);
                        log.InfoFormat("向redis中写入:{0}", result);
                    });
                }
                catch (WebException e)
                {
                    count++;
                    log.ErrorFormat("报警次数加一：{0}下载天气信息发生异常：{1}", count, e);
                    if (count == 3)
                    {
                        log.Error("报警次数已经累计三次，将终止所有请求");
                        terminationRequest = true;
                    }
                }
                catch (Exception e)
                {
                    log.ErrorFormat("下载天气信息发生异常,终止所有请求,{0}",e);
                    terminationRequest = true;
                }
            } while (list.Count > 0 && terminationRequest == false);
        }

    }
}
