// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nhom2ki3.Data;

namespace Nhom2ki3.Migrations
{
    [DbContext(typeof(Nhom2ki3Context))]
    partial class Nhom2ki3ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nhom2ki3.Models.ChiTietHoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HoaDonsId")
                        .HasColumnType("int");

                    b.Property<int>("IdHoaDon")
                        .HasColumnType("int");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<int?>("SanPhamsId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HoaDonsId");

                    b.HasIndex("SanPhamsId");

                    b.ToTable("ChiTietHoaDon");
                });

            modelBuilder.Entity("Nhom2ki3.Models.HoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdKH")
                        .HasColumnType("int");

                    b.Property<int?>("KhachHangsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayXuat")
                        .HasColumnType("datetime2");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KhachHangsId");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("Nhom2ki3.Models.KhachHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapDo")
                        .HasColumnType("int");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("Nhom2ki3.Models.Kho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKho")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kho");
                });

            modelBuilder.Entity("Nhom2ki3.Models.LoaiSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiSanPham");
                });

            modelBuilder.Entity("Nhom2ki3.Models.NhaMay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNhaMay")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NhaMay");
                });

            modelBuilder.Entity("Nhom2ki3.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdLoaiSP")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiSanPhamsId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoaiSanPhamsId");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("Nhom2ki3.Models.SanPhamKho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdKho")
                        .HasColumnType("int");

                    b.Property<int>("IdSP")
                        .HasColumnType("int");

                    b.Property<int?>("KhosId")
                        .HasColumnType("int");

                    b.Property<int?>("SanPhamsId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KhosId");

                    b.HasIndex("SanPhamsId");

                    b.ToTable("SanPhamKho");
                });

            modelBuilder.Entity("Nhom2ki3.Models.ChiTietHoaDon", b =>
                {
                    b.HasOne("Nhom2ki3.Models.HoaDon", "HoaDons")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("HoaDonsId");

                    b.HasOne("Nhom2ki3.Models.SanPham", "SanPhams")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("SanPhamsId");

                    b.Navigation("HoaDons");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("Nhom2ki3.Models.HoaDon", b =>
                {
                    b.HasOne("Nhom2ki3.Models.KhachHang", "KhachHangs")
                        .WithMany("HoaDons")
                        .HasForeignKey("KhachHangsId");

                    b.Navigation("KhachHangs");
                });

            modelBuilder.Entity("Nhom2ki3.Models.SanPham", b =>
                {
                    b.HasOne("Nhom2ki3.Models.LoaiSanPham", "LoaiSanPhams")
                        .WithMany("SanPhams")
                        .HasForeignKey("LoaiSanPhamsId");

                    b.Navigation("LoaiSanPhams");
                });

            modelBuilder.Entity("Nhom2ki3.Models.SanPhamKho", b =>
                {
                    b.HasOne("Nhom2ki3.Models.Kho", "Khos")
                        .WithMany("SanPhamKhos")
                        .HasForeignKey("KhosId");

                    b.HasOne("Nhom2ki3.Models.SanPham", "SanPhams")
                        .WithMany("SanPhamKhos")
                        .HasForeignKey("SanPhamsId");

                    b.Navigation("Khos");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("Nhom2ki3.Models.HoaDon", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("Nhom2ki3.Models.KhachHang", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("Nhom2ki3.Models.Kho", b =>
                {
                    b.Navigation("SanPhamKhos");
                });

            modelBuilder.Entity("Nhom2ki3.Models.LoaiSanPham", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("Nhom2ki3.Models.SanPham", b =>
                {
                    b.Navigation("ChiTietHoaDons");

                    b.Navigation("SanPhamKhos");
                });
#pragma warning restore 612, 618
        }
    }
}
