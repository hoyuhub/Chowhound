using System;
using Common;
using Common.Redis;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Text;
public class WeatherUpdaeCon
{
    //更新天气    
    public void WeatherUpdate()
    {

    }


    public void test()
    {
        string filePath = "e:/桌面/test.csv";
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var rader=new StreamReader(stream))
            {
             string ss=   rader.ReadLine();
            }
            
        }
    }

}