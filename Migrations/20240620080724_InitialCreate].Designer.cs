﻿// <auto-generated />
using System;
using BitcoinPriceFetcher.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BitcoinPriceFetcher.Migrations
{
    [DbContext(typeof(BitcoinPriceContext))]
    [Migration("20240620080724_InitialCreate]")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("BitcoinPriceFetcher.Models.BitcoinPrice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("BitcoinPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
