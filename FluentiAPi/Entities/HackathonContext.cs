using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FluentiAPi.Entities;

public partial class HackathonContext : DbContext
{
    public HackathonContext()
    {
    }

    public HackathonContext(DbContextOptions<HackathonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> ProductsManagements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local); Initial Catalog=hackathon; Trusted_Connection=True; TrustServerCertificate=True; user id = LAPTOP-C6NC4U0J\\HP");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__D54EE9B4CE00BDEF");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF5D4D650F4");

            entity.ToTable("products_management");

            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ProdBrand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prod_brand");
            entity.Property(e => e.ProdDescription)
                .IsUnicode(false)
                .HasColumnName("prod_description");
            entity.Property(e => e.ProdName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("prod_name");
            entity.Property(e => e.ProdPrice).HasColumnName("prod_price");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductsManagements)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
