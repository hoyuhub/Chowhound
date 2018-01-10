using System;

namespace Models
{
    public class XCity
    {
        public XCity() { }
        public XCity(string id, string name, string EName, string Administrative1, string AdministrativeE1, string Administrative2, string AdministrativeE2,string TimeZone,string CityLevel)
        {
            this.Id = id;
            this.Name = name;
            this.EName = EName;
            this.Administrative1=Administrative1;
            this.AdministrativeE1=AdministrativeE1;
            this.Administrative2=Administrative2;
            this.AdministrativeE2=AdministrativeE2;
            this.TimeZone=TimeZone;
            this.CityLevel=CityLevel;
        }

        //城市id（映射心知天气网）
        public string Id { get; set; }
        //名称
        public string Name { get; set; }
        //英文名称
        public string EName { get; set; }
        //行政归属1
        public string Administrative1 { get; set; }
        //行政归属1（英文）
        public string AdministrativeE1 { get; set; }
        //行政归属2
        public string Administrative2 { get; set; }
        //行政归属2（英文）
        public string AdministrativeE2 { get; set; }
        //时区
        public string TimeZone { get; set; }
        //城市级别
        public string CityLevel { get; set; }

    }
}