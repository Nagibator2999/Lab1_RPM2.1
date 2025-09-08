using System;
using System.Collections.Generic;
using Lab1_RPM2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1_RPM2.Data;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPartner> ProductPartners { get; set; }

    public virtual DbSet<TypeProduct> TypeProducts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server = dbsrv\\YAR2024; Database = BD_Dub_SKN; Trusted_Connection = True; TrustServerCertificate = True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK__Material__78A1A19C62601DC4");

            entity.Property(e => e.Number).ValueGeneratedNever();
            entity.Property(e => e.PercentDefect).HasColumnName("Percent_defect");
            entity.Property(e => e.TypeMaterial)
                .HasMaxLength(255)
                .HasColumnName("Type_material");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Inn).HasName("PK__Partners__C490CCF48FB8A7DC");

            entity.Property(e => e.Inn)
                .ValueGeneratedNever()
                .HasColumnName("INN");
            entity.Property(e => e.Director).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("Phone_number");
            entity.Property(e => e.TitlePa).HasMaxLength(255);
            entity.Property(e => e.TypePartner)
                .HasMaxLength(255)
                .HasColumnName("Type_partner");
            entity.Property(e => e.UrAdress)
                .HasMaxLength(255)
                .HasColumnName("Ur_adress");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Article).HasName("PK__Product__4943444BF470F96B");

            entity.ToTable("Product");

            entity.Property(e => e.Article).ValueGeneratedNever();
            entity.Property(e => e.MinPrice).HasColumnName("Min_price");
            entity.Property(e => e.TitlePr).HasMaxLength(255);
            entity.Property(e => e.TypeProduct).HasColumnName("Type_product");

            entity.HasOne(d => d.TypeProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeProduct)
                .HasConstraintName("FK__Product__Type_pr__47DBAE45");
        });

        modelBuilder.Entity<ProductPartner>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK__Product___78A1A19C6CBE238C");

            entity.ToTable("Product_partner");

            entity.Property(e => e.Number).ValueGeneratedNever();
            entity.Property(e => e.ArticleProduct).HasColumnName("Article_product");
            entity.Property(e => e.DateSales)
                .HasColumnType("datetime")
                .HasColumnName("Date_sales");
            entity.Property(e => e.InnPatners).HasColumnName("INN_patners");
            entity.Property(e => e.QuantityProducts).HasColumnName("Quantity_products");

            entity.HasOne(d => d.ArticleProductNavigation).WithMany(p => p.ProductPartners)
                .HasForeignKey(d => d.ArticleProduct)
                .HasConstraintName("FK__Product_p__Artic__4AB81AF0");

            entity.HasOne(d => d.InnPatnersNavigation).WithMany(p => p.ProductPartners)
                .HasForeignKey(d => d.InnPatners)
                .HasConstraintName("FK__Product_p__INN_p__4BAC3F29");
        });

        modelBuilder.Entity<TypeProduct>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK__Type_Pro__78A1A19CA09EE91A");

            entity.ToTable("Type_Product");

            entity.Property(e => e.Number).ValueGeneratedNever();
            entity.Property(e => e.TypeKoef).HasColumnName("type_koef");
            entity.Property(e => e.TypeP).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CDF14A4C2DE");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userID");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .HasColumnName("fio");
            entity.Property(e => e.Login1)
                .HasMaxLength(255)
                .HasColumnName("login1");
            entity.Property(e => e.Password1)
                .HasMaxLength(255)
                .HasColumnName("password1");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Type1)
                .HasMaxLength(255)
                .HasColumnName("type1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
