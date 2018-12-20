﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyWebApp.Models;

namespace MyWebApp.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyWebApp.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Orderid");

                    b.Property<DateTime>("data");

                    b.HasKey("id");

                    b.HasIndex("Orderid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyWebApp.Models.OrderItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("productid");

                    b.Property<int>("quantity");

                    b.HasKey("id");

                    b.HasIndex("productid");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("MyWebApp.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name");

                    b.Property<double>("price");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MyWebApp.Models.Order", b =>
                {
                    b.HasOne("MyWebApp.Models.Order")
                        .WithMany("orders")
                        .HasForeignKey("Orderid");
                });

            modelBuilder.Entity("MyWebApp.Models.OrderItem", b =>
                {
                    b.HasOne("MyWebApp.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productid");
                });
#pragma warning restore 612, 618
        }
    }
}
