﻿// <auto-generated />
using AmazonDream.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonDream.DAL.Migrations
{
    [DbContext(typeof(AmazonDreamDbContext))]
    [Migration("20190905173824_producttrend")]
    partial class producttrend
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AmazonDream.Entities.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("ADMIN");
                });

            modelBuilder.Entity("AmazonDream.Entities.Customer", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("CUSTOMER");
                });

            modelBuilder.Entity("AmazonDream.Entities.Product", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductBrand")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ProductDiscount");

                    b.Property<string>("ProductGenderType")
                        .IsRequired();

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long>("ProductPrice");

                    b.Property<int>("ProductQuantity");

                    b.Property<int>("ProductQuantityInKart");

                    b.Property<string>("ProductStatus")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ProductSubCategory")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ProductTrend")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("Seller_ID");

                    b.HasKey("ID");

                    b.HasIndex("Seller_ID");

                    b.ToTable("PRODUCT");
                });

            modelBuilder.Entity("AmazonDream.Entities.ProductPicture", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PicturePath")
                        .IsRequired();

                    b.Property<long>("Product_ID");

                    b.HasKey("ID");

                    b.HasIndex("Product_ID");

                    b.ToTable("PRODUCTPICTURE");
                });

            modelBuilder.Entity("AmazonDream.Entities.Seller", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("SELLER");
                });

            modelBuilder.Entity("AmazonDream.Entities.Product", b =>
                {
                    b.HasOne("AmazonDream.Entities.Seller", "Seller")
                        .WithMany("Product")
                        .HasForeignKey("Seller_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AmazonDream.Entities.ProductPicture", b =>
                {
                    b.HasOne("AmazonDream.Entities.Product", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("Product_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
