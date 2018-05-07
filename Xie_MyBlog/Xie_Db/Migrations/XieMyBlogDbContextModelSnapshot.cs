﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Xie_Db;

namespace Xie_Db.Migrations
{
    [DbContext(typeof(XieMyBlogDbContext))]
    partial class XieMyBlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Xie_BlogData.Data.XBlogLog", b =>
                {
                    b.Property<string>("FID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FID")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime");

                    b.Property<string>("Creator")
                        .HasColumnName("Creator")
                        .HasMaxLength(50);

                    b.Property<bool?>("IsDelete")
                        .HasColumnName("IsDelete");

                    b.Property<string>("LogInfo")
                        .HasColumnName("LogInfo")
                        .HasMaxLength(200);

                    b.Property<int?>("LogSign")
                        .HasColumnName("LogSign");

                    b.Property<string>("Orgnazation")
                        .HasColumnName("Orgnazation")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnName("UpdateTime");

                    b.Property<string>("Updator")
                        .HasColumnName("Updator")
                        .HasMaxLength(50);

                    b.HasKey("FID");

                    b.ToTable("XBlogLog");
                });

            modelBuilder.Entity("Xie_BlogData.Data.XBlogUser", b =>
                {
                    b.Property<string>("FID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FID")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime");

                    b.Property<string>("Creator")
                        .HasColumnName("Creator")
                        .HasMaxLength(50);

                    b.Property<bool?>("IsAction")
                        .HasColumnName("IsAction");

                    b.Property<bool?>("IsDelete")
                        .HasColumnName("IsDelete");

                    b.Property<string>("NickName")
                        .HasColumnName("NickName")
                        .HasMaxLength(50);

                    b.Property<string>("Orgnazation")
                        .HasColumnName("Orgnazation")
                        .HasMaxLength(50);

                    b.Property<string>("PassWord")
                        .HasColumnName("PassWord")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnName("UpdateTime");

                    b.Property<string>("Updator")
                        .HasColumnName("Updator")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .HasColumnName("UserName")
                        .HasMaxLength(50);

                    b.HasKey("FID");

                    b.ToTable("XBlogUser");
                });
#pragma warning restore 612, 618
        }
    }
}
