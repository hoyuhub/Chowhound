using System;

namespace Models
{
    //心知天气接口调用记录
    public class HistoricalXinZhiAPI
    {
        public HistoricalXinZhiAPI() { }
        public HistoricalXinZhiAPI(string id, DateTime callTime, int count)
        {
            this.id = id;
            this.CallTime = callTime;
            this.Count = count;
        }
        public string id { get; set; }

        public DateTime CallTime { get; set; }

        public int Count { get; set; }

    }
}