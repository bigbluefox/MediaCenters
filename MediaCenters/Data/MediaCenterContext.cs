using System;
using System.Collections.Generic;
using MediaCenters.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaCenters.Data;

public partial class MediaCenterContext : DbContext
{
    public MediaCenterContext()
    {
    }

    public MediaCenterContext(DbContextOptions<MediaCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Audio> Audios { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<MediaTag> MediaTags { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=D:\\Codes\\Db\\SQLite\\MediaCenter.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("Article");

            entity.HasIndex(e => e.Id, "IX_Article_Id").IsUnique();

            entity.Property(e => e.Abstract).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Author).HasColumnType("VARCHAR (50)");
            entity.Property(e => e.CreateTime).HasColumnType("DATETIME");
            entity.Property(e => e.Source).HasColumnType("VARCHAR (50)");
            entity.Property(e => e.Title).HasColumnType("VARCHAR (128)");
        });

        modelBuilder.Entity<Audio>(entity =>
        {
            entity.ToTable("Audio");

            entity.HasIndex(e => e.Id, "IX_Audio_Id").IsUnique();

            entity.Property(e => e.Album).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Artist).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.ContentType).HasColumnType("VARCHAR (128)");
            entity.Property(e => e.CreationTime).HasColumnType("VARCHAR (24)");
            entity.Property(e => e.DirectoryName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Extension).HasColumnType("VARCHAR (8)");
            entity.Property(e => e.FullName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Md5)
                .HasColumnType("VARCHAR (128)")
                .HasColumnName("MD5");
            entity.Property(e => e.Name).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Sha1)
                .HasColumnType("VARCHAR (160)")
                .HasColumnName("SHA1");
            entity.Property(e => e.Title).HasColumnType("VARCHAR (255)");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.HasIndex(e => e.Id, "IX_Book_Id").IsUnique();

            entity.Property(e => e.ContentType).HasColumnType("VARCHAR (128)");
            entity.Property(e => e.CreationTime).HasColumnType("VARCHAR (24)");
            entity.Property(e => e.DirectoryName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Extension).HasColumnType("VARCHAR (8)");
            entity.Property(e => e.FullName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Md5)
                .HasColumnType("VARCHAR (128)")
                .HasColumnName("MD5");
            entity.Property(e => e.Name).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Sha1)
                .HasColumnType("VARCHAR (160)")
                .HasColumnName("SHA1");
            entity.Property(e => e.Size).HasColumnType("BIGINT");
            entity.Property(e => e.Title).HasColumnType("VARCHAR (255)");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.ToTable("Image");

            entity.HasIndex(e => e.Id, "IX_Image_Id").IsUnique();

            entity.Property(e => e.ContentType).HasColumnType("VARCHAR (128)");
            entity.Property(e => e.CreationTime).HasColumnType("VARCHAR (24)");
            entity.Property(e => e.DirectoryName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Extension).HasColumnType("VARCHAR (8)");
            entity.Property(e => e.FullName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Md5)
                .HasColumnType("VARCHAR (128)")
                .HasColumnName("MD5");
            entity.Property(e => e.Name).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Sha1)
                .HasColumnType("VARCHAR (160)")
                .HasColumnName("SHA1");
            entity.Property(e => e.Title).HasColumnType("VARCHAR (255)");
        });

        modelBuilder.Entity<MediaTag>(entity =>
        {
            entity.ToTable("MediaTag");

            entity.HasIndex(e => e.Id, "IX_MediaTag_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MediaId).HasColumnName("MediaID");
            entity.Property(e => e.TagId).HasColumnName("TagID");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.ToTable("Medium");

            entity.HasIndex(e => e.Id, "IX_Medium_Id").IsUnique();

            entity.Property(e => e.Album).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Artist).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.ContentType).HasColumnType("VARCHAR (128)");
            entity.Property(e => e.CreationTime).HasColumnType("VARCHAR (24)");
            entity.Property(e => e.DirectoryName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Extension).HasColumnType("VARCHAR (8)");
            entity.Property(e => e.FullName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Md5)
                .HasColumnType("VARCHAR (128)")
                .HasColumnName("MD5");
            entity.Property(e => e.Name).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Sha1)
                .HasColumnType("VARCHAR (160)")
                .HasColumnName("SHA1");
            entity.Property(e => e.Size).HasColumnType("BIGINT");
            entity.Property(e => e.Title).HasColumnType("VARCHAR (255)");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasIndex(e => e.Id, "IX_Tags_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Type).HasDefaultValue(0);
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.ToTable("UserInfo");

            entity.HasIndex(e => e.Id, "IX_UserInfo_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasColumnType("VARCHAR (255)")
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasColumnType("VARCHAR (255)")
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasColumnType("VARCHAR (255)")
                .HasColumnName("lastname");
            entity.Property(e => e.Phone)
                .HasColumnType("VARCHAR (255)")
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.ToTable("Video");

            entity.HasIndex(e => e.Id, "IX_Video_Id").IsUnique();

            entity.Property(e => e.ContentType).HasColumnType("VARCHAR (128)");
            entity.Property(e => e.CreationTime).HasColumnType("VARCHAR (24)");
            entity.Property(e => e.DirectoryName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Extension).HasColumnType("VARCHAR (8)");
            entity.Property(e => e.FullName).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Md5)
                .HasColumnType("VARCHAR (128)")
                .HasColumnName("MD5");
            entity.Property(e => e.Name).HasColumnType("VARCHAR (255)");
            entity.Property(e => e.Sha1)
                .HasColumnType("VARCHAR (160)")
                .HasColumnName("SHA1");
            entity.Property(e => e.Title).HasColumnType("VARCHAR (255)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
