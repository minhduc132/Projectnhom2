﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using agement2.Data;

#nullable disable

namespace agement2.Migrations
{
    [DbContext(typeof(agement2Context))]
    partial class agement2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("agement2.Models.QLdiem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Exercise")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Practice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("QLhockiId")
                        .HasColumnType("int");

                    b.Property<int?>("QLmonhocId")
                        .HasColumnType("int");

                    b.Property<int>("QLsinhvienId")
                        .HasColumnType("int");

                    b.Property<decimal>("Theory")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("QLhockiId");

                    b.HasIndex("QLmonhocId");

                    b.HasIndex("QLsinhvienId");

                    b.ToTable("QLdiem");
                });

            modelBuilder.Entity("agement2.Models.QLhocki", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QLhocki");
                });

            modelBuilder.Entity("agement2.Models.QLmonhoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Semester")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("QLmonhoc");
                });

            modelBuilder.Entity("agement2.Models.QLsinhvien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Phonenumber")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("QLsinhvien");
                });

            modelBuilder.Entity("agement2.Models.QLdiem", b =>
                {
                    b.HasOne("agement2.Models.QLhocki", null)
                        .WithMany("QLdiems")
                        .HasForeignKey("QLhockiId");

                    b.HasOne("agement2.Models.QLmonhoc", null)
                        .WithMany("QLdiem")
                        .HasForeignKey("QLmonhocId");

                    b.HasOne("agement2.Models.QLsinhvien", "QLsinhviens")
                        .WithMany("QLdiem")
                        .HasForeignKey("QLsinhvienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QLsinhviens");
                });

            modelBuilder.Entity("agement2.Models.QLhocki", b =>
                {
                    b.Navigation("QLdiems");
                });

            modelBuilder.Entity("agement2.Models.QLmonhoc", b =>
                {
                    b.Navigation("QLdiem");
                });

            modelBuilder.Entity("agement2.Models.QLsinhvien", b =>
                {
                    b.Navigation("QLdiem");
                });
#pragma warning restore 612, 618
        }
    }
}
