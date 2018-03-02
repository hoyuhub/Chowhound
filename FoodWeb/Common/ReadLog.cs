using System;
using log4net;

namespace FoodWeb.Common
{
    
    public class ReadLog
    {
        private ILog log=LogManager.GetLogger(Startup.repository.Name,typeof(ReadLog));

        private static string basePath=Environment.CurrentDirectory;
        private static string logAll= basePath;
        private static string logError=basePath+"\\error\\";
        public void Read()
        {
        }
    }
}