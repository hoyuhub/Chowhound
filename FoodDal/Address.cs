using System;
using System.Collections.Generic;
using Models;
using FoodDal;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodDal
{
    public class Address
    {

        //获取所有省份信息
        public List<SProvince> Province()
        {
            using (var ct = new FoodDBContext())
            {
                return ct.SProvinces.ToList();
            }

        }

        //获取所有地区信息
        public List<SDistrict> District()
        {
            using (var ct = new FoodDBContext())
            {
                return ct.SDistricts.ToList();
            }
        }

        //根据城市id 获取地区信息
        public List<SDistrict> District(int cityId)
        {
            using (var ct = new FoodDBContext())
            {
                return ct.SDistricts.Where(d => d.CityId == cityId).ToList();
            }
        }

        //获取所有城市信息
        public List<SCity> City()
        {
            using (var ct = new FoodDBContext())
            {
                return ct.SCitys.ToList();
            }
        }

        //根据省份id 获取城市信息
        public List<SCity> City(int provinceId)
        {
            using (var ct = new FoodDBContext())
            {
                return ct.SCitys.Where(d => d.ProvinceId == provinceId).ToList();
            }
        }

        public int AddCity(List<XCity> list)
        {
            using (var ct = new FoodDBContext())
            {
                ct.XCitys.AddRange(list);
                return ct.SaveChanges();
            }
        }

        public List<XCity> GetXCity(string CityLevel)
        {
            using (var ct = new FoodDBContext())
            {
                return ct.XCitys.Where(d => d.CityLevel == CityLevel).ToList();

            }
        }
    }}