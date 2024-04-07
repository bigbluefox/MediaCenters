﻿// <auto-generated />
using System;
using MediaCenters.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediaCenters.Migrations
{
    [DbContext(typeof(MediaCenterContext))]
    [Migration("20240229094156_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("MediaCenters.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abstract")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Author")
                        .HasColumnType("VARCHAR (50)");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Source")
                        .HasColumnType("VARCHAR (50)");

                    b.Property<string>("Title")
                        .HasColumnType("VARCHAR (128)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Article_Id")
                        .IsUnique();

                    b.ToTable("Article", (string)null);
                });

            modelBuilder.Entity("MediaCenters.Models.Audio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Album")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Artist")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("ContentType")
                        .HasColumnType("VARCHAR (128)");

                    b.Property<string>("CreationTime")
                        .HasColumnType("VARCHAR (24)");

                    b.Property<string>("DirectoryName")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extension")
                        .HasColumnType("VARCHAR (8)");

                    b.Property<string>("FullName")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Md5")
                        .HasColumnType("VARCHAR (128)")
                        .HasColumnName("MD5");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Sha1")
                        .HasColumnType("VARCHAR (160)")
                        .HasColumnName("SHA1");

                    b.Property<int?>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("VARCHAR (255)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Audio_Id")
                        .IsUnique();

                    b.ToTable("Audio", (string)null);
                });

            modelBuilder.Entity("MediaCenters.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentType")
                        .HasColumnType("VARCHAR (128)");

                    b.Property<string>("CreationTime")
                        .HasColumnType("VARCHAR (24)");

                    b.Property<string>("DirectoryName")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Extension")
                        .HasColumnType("VARCHAR (8)");

                    b.Property<string>("FullName")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Md5")
                        .HasColumnType("VARCHAR (128)")
                        .HasColumnName("MD5");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Sha1")
                        .HasColumnType("VARCHAR (160)")
                        .HasColumnName("SHA1");

                    b.Property<long?>("Size")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Title")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Book_Id")
                        .IsUnique();

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("MediaCenters.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentType")
                        .HasColumnType("VARCHAR (128)");

                    b.Property<string>("CreationTime")
                        .HasColumnType("VARCHAR (24)");

                    b.Property<string>("DirectoryName")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Extension")
                        .HasColumnType("VARCHAR (8)");

                    b.Property<string>("FullName")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Md5")
                        .HasColumnType("VARCHAR (128)")
                        .HasColumnName("MD5");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Sha1")
                        .HasColumnType("VARCHAR (160)")
                        .HasColumnName("SHA1");

                    b.Property<int?>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Image_Id")
                        .IsUnique();

                    b.ToTable("Image", (string)null);
                });

            modelBuilder.Entity("MediaCenters.Models.MediaTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<int?>("MediaId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("MediaID");

                    b.Property<int?>("TagId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("TagID");

                    b.Property<int?>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_MediaTag_ID")
                        .IsUnique();

                    b.ToTable("MediaTag", (string)null);
                });

            modelBuilder.Entity("MediaCenters.Models.Medium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Album")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Artist")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("ContentType")
                        .HasColumnType("VARCHAR (128)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("VARCHAR (24)");

                    b.Property<string>("DirectoryName")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extension")
                        .HasColumnType("VARCHAR (8)");

                    b.Property<string>("FullName")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Md5")
                        .HasColumnType("VARCHAR (128)")
                        .HasColumnName("MD5");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Sha1")
                        .HasColumnType("VARCHAR (160)")
                        .HasColumnName("SHA1");

                    b.Property<long?>("Size")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Title")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Medium_Id")
                        .IsUnique();

                    b.ToTable("Medium", (string)null);
                });

            modelBuilder.Entity("MediaCenters.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Tags_ID")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MediaCenters.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR (255)")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .HasColumnType("VARCHAR (255)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .HasColumnType("VARCHAR (255)")
                        .HasColumnName("lastname");

                    b.Property<string>("Phone")
                        .HasColumnType("VARCHAR (255)")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_UserInfo_id")
                        .IsUnique();

                    b.ToTable("UserInfo", (string)null);
                });

            modelBuilder.Entity("MediaCenters.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentType")
                        .HasColumnType("VARCHAR (128)");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("VARCHAR (24)");

                    b.Property<string>("DirectoryName")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extension")
                        .HasColumnType("VARCHAR (8)");

                    b.Property<string>("FullName")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Md5")
                        .HasColumnType("VARCHAR (128)")
                        .HasColumnName("MD5");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<string>("Sha1")
                        .HasColumnType("VARCHAR (160)")
                        .HasColumnName("SHA1");

                    b.Property<int?>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("VARCHAR (255)");

                    b.Property<int?>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Video_Id")
                        .IsUnique();

                    b.ToTable("Video", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
