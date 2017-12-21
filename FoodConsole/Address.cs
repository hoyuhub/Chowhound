using System;
using System.Collections.Generic;
using Models;
using EntityFrameWorkDal;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodConsole
{
    public class Address
    {
        List<SCity> listCity = new List<SCity>();
        List<SProvince> listProvice = new List<SProvince>();
        List<SDistrict> listDistrict = new List<SDistrict>();
        public Address Province()
        {
            using (var ct = new FoodDBContext())
            {
                //[NotNullAttribute] this IQueryable<TSource> source, CancellationToken cancellationToken = default(CancellationToken)
                listProvice = ct.SProvince.ToList();
            }

            listProvice.ForEach(d => Console.WriteLine(d.ProvinceName));
            return this;
        }

        public void District()
        {
            using (var ct = new FoodDBContext())
            {
                listDistrict = ct.SDistrict.ToList();
            }
            listDistrict.ForEach(d => Console.WriteLine(d.DistrictName));
        }
    }
}