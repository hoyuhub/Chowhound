using System;

namespace Models
{

    public class HistoricalWeather
    {

        public string id { get; set; }

        public string CityId { get; set; }

        public DateTime Date { get; set; }
        
        public DateTime CurrentDate { get; set; }

        public string TextDay { get; set; }

        public int CodeDay { get; set; }

        public string TextNight { get; set; }

        public int CodeNight { get; set; }

        public int High { get; set; }

        public int Low { get; set; }

        public string Precip { get; set; }

        public string WindDirection { get; set; }

        public string WindDirectionDegree { get; set; }

        public int WindSpeed { get; set; }

        public int WindScale { get; set; }
    }
}