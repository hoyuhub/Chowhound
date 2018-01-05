using System;
using System.Net.Http;
using System.Net;
using System.Text;
namespace Common
{
    public class Weather
    {
        //心知天气API key
        private static string apiKey = "tvwzmnqbgga053xr";
        //心知天气用户ID
        private static string userId = "UD7AD56A5E";
        //心知天气接口路径
        private static string url="https://api.seniverse.com/v3/weather/";
        //创建静态客户端对象
        private static WebClient client = new WebClient();
        
        //获取天气实况
        public string GetNowWeather()
        {
            string url = "now.json?key=tvwzmnqbgga053xr&location=beijing&language=zh-Hans";
            byte[] bResponse = client.DownloadData(url);
            string strResponse = Encoding.UTF8.GetString(bResponse);
            return strResponse;
        }

        
    }
}
