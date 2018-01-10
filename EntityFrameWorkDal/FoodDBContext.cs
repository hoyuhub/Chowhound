using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;
using Microsoft.Extensions.Configuration;

using System.IO;

namespace EntityFrameWorkDal
{
    public class Connections
    {
        public string connStr { get; set; }
    }

    public partial class FoodDBContext : DbContext
    {
        public virtual DbSet<SCity> SCitys { get; set; }
        public virtual DbSet<SDistrict> SDistricts { get; set; }
        public virtual DbSet<SProvince> SProvinces { get; set; }
        public virtual DbSet<XCity> XCitys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json").Build();
                var appConfig = new Connections();
                builder.GetSection("Connections").Bind(appConfig);
                optionsBuilder.UseSqlServer(appConfig.connStr);
            }
        }

    }


}
