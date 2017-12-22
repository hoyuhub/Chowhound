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

        //获取所有省份信息
        public List<SProvince> Province()
        {
            using (var ct = new FoodDBContext())
            {
                return ct.SProvince.ToList();
            }

        }

        //获取所有地区信息
        public List<SDistrict> District()
        {
            using (var ct = new FoodDBContext())
            {
                return ct.SDistrict.ToList();
            }
        }

        //根据城市id 获取地区信息
        public List<SDistrict> District(int cityId)
        {
            using (var ct = new FoodDBContext())
            {
                return ct.SDistrict.Where(d => d.CityId == cityId).ToList();
            }
        }

        //获取所有城市信息
        public List<SCity> City()
        {
            using (var ct = new FoodDBContext())
            {
                return ct.SCity.ToList();
            }
        }

        //根据省份id 获取城市信息
        public List<SCity> City(int provinceId)
        {
            using (var ct = new FoodDBContext())
            {
                return ct.SCity.Where(d => d.ProvinceId == provinceId).ToList();
            }
        }
    }
}