using CRUD_Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Demo.Data
{
    public partial class ProductsContext : DbContext
    {
        public ProductsContext() { }
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }
        public virtual DbSet<Apple> Apples { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code.You can avoid scaffolding the connection string by using the Name = syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlite("Data Source=.\\Db\\Products.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apple>(entity =>
            {
                entity.HasKey(e => e.Barcode);
                entity.Property(e => e.Barcode).HasColumnType("VARCHAR");
                entity.Property(e => e.Brand).HasColumnType("VARCHAR");
                entity.Property(e => e.Name).HasColumnType("VARCHAR");
                entity.Property(e => e.PruchasePrice).HasColumnType("DOUBLE");
                entity.Property(e => e.SellingPrice).HasColumnType("DOUBLE");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}