using System;
using log4net;
using System.Collections.Generic;
using System.IO;

namespace FoodWeb.Common
{

    public class ReadLog
    {
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(ReadLog));

        private static string basePath = Environment.CurrentDirectory;
        private static string logAll = basePath;
        private static string logError = basePath + "\\error\\";
        public void Read()
        {
        }

        //获取指定路径下的所有日志名称
        public string[] GetFileName(string path)
        {
            List<string> list = new List<string>();
            var files =Directory.GetFiles(path,"*.log");
            return files;
        }
    }
}