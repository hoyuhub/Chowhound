﻿// <auto-generated />
using EntityFrameWorkDal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EntityFrameWorkDal.Migrations
{
    [DbContext(typeof(FoodDBContext))]
    partial class FoodDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.SCity", b =>
                {
                    b.Property<long>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CityID");

                    b.Property<string>("CityName")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime");

                    b.Property<long?>("ProvinceId")
                        .HasColumnName("ProvinceID");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(50);

                    b.HasKey("CityId");

                    b.ToTable("S_City");
                });

            modelBuilder.Entity("Models.SDistrict", b =>
                {
                    b.Property<long>("DistrictId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DistrictID");

                    b.Property<long?>("CityId")
                        .HasColumnName("CityID");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime");

                    b.Property<string>("DistrictName")
                        .HasMaxLength(50);

                    b.HasKey("DistrictId");

                    b.ToTable("S_District");
                });

            modelBuilder.Entity("Models.SProvince", b =>
                {
                    b.Property<long>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProvinceID");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime");

                    b.Property<string>("ProvinceName")
                        .HasMaxLength(50);

                    b.HasKey("ProvinceId");

                    b.ToTable("S_Province");
                });
#pragma warning restore 612, 618
        }
    }
}
