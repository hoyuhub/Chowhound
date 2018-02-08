using System;
using System.Collections.Generic;
using Models;
using EntityFrameWorkDal;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityFrameWorkDal
{

    public class HistoricalWeathersDal
    {
        public void Add(List<HistoricalWeather> list)
        {
            using (var cx = new FoodDBContext())
            {
                cx.HistoricalWeathers.AddRange(list);
                cx.SaveChanges();
            }

        }
    }
}