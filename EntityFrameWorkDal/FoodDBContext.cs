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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder =new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json").Build();
                var appConfig = new Connections();
                builder.GetSection("Connections").Bind(appConfig);
                optionsBuilder.UseSqlServer(appConfig.connStr);
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("S_City");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.ZipCode).HasMaxLength(50);
            });

            modelBuilder.Entity<SDistrict>(entity =>
            {
                entity.HasKey(e => e.DistrictId);

                entity.ToTable("S_District");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.DistrictName).HasMaxLength(50);
            });

            modelBuilder.Entity<SProvince>(entity =>
            {
                entity.HasKey(e => e.ProvinceId);

                entity.ToTable("S_Province");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.ProvinceName).HasMaxLength(50);
            });
        }
    }


}
