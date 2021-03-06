﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderApp.Models;

namespace OrderApp.Migrations
{
    [DbContext(typeof(OrderAppContext))]
    [Migration("20190127143023_Update2")]
    partial class Update2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderApp.Model.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("ID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("OrderApp.Model.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("OrderApp.Model.MenuItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int?>("RestaurantID");

                    b.HasKey("ID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("OrderApp.Model.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CompletionTime");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("CustomerID");

                    b.Property<int>("RestaurantID");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("OrderApp.Model.OrderMenuItem", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("MenuItemId");

                    b.HasKey("OrderId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("OrderMenuItem");
                });

            modelBuilder.Entity("OrderApp.Model.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("ID");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("OrderApp.Model.MenuItem", b =>
                {
                    b.HasOne("OrderApp.Model.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID");
                });

            modelBuilder.Entity("OrderApp.Model.Order", b =>
                {
                    b.HasOne("OrderApp.Model.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OrderApp.Model.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrderApp.Model.OrderMenuItem", b =>
                {
                    b.HasOne("OrderApp.Model.MenuItem", "MenuItem")
                        .WithMany("OrdersLink")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OrderApp.Model.Order", "Order")
                        .WithMany("MenuItemsLink")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
