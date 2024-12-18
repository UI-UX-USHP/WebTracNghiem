﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TracNghiem.Models;

public partial class TracNghiemContext : DbContext
{
    public TracNghiemContext()
    {
    }

    public TracNghiemContext(DbContextOptions<TracNghiemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCauHoi> TbCauHois { get; set; }

    public virtual DbSet<TbDeThi> TbDeThis { get; set; }

    public virtual DbSet<TbDeThiCauHoi> TbDeThiCauHois { get; set; }

    public virtual DbSet<TbKetQua> TbKetQuas { get; set; }

    public virtual DbSet<TbMonHoc> TbMonHocs { get; set; }

    public virtual DbSet<TbMucDo> TbMucDos { get; set; }

    public virtual DbSet<TbThanhVien> TbThanhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=c500sv.database.windows.net,1433;Initial Catalog=tracnghiem;User ID=tnlogin;Password=@Abc123456;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("db_accessadmin")
            .UseCollation("Vietnamese_CI_AS");

        modelBuilder.Entity<TbCauHoi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CauHois");

            entity.ToTable("tbCauHoi", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CauHoi).HasMaxLength(250);
            entity.Property(e => e.DapAn)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.DapAnA)
                .HasMaxLength(250)
                .HasColumnName("DapAn_a");
            entity.Property(e => e.DapAnB)
                .HasMaxLength(250)
                .HasColumnName("DapAn_b");
            entity.Property(e => e.DapAnC)
                .HasMaxLength(250)
                .HasColumnName("DapAn_c");
            entity.Property(e => e.DapAnD)
                .HasMaxLength(250)
                .HasColumnName("DapAn_d");
            entity.Property(e => e.GhiChu).HasMaxLength(250);

            entity.HasOne(d => d.MaMonHocNavigation).WithMany(p => p.TbCauHois)
                .HasForeignKey(d => d.MaMonHoc)
                .HasConstraintName("FK_CauHois_MonHocs");

            entity.HasOne(d => d.MaMucDoNavigation).WithMany(p => p.TbCauHois)
                .HasForeignKey(d => d.MaMucDo)
                .HasConstraintName("FK_CauHois_MucDos");
        });

        modelBuilder.Entity<TbDeThi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DeThis");

            entity.ToTable("tbDeThi", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TenDeThi).HasMaxLength(50);
        });

        modelBuilder.Entity<TbDeThiCauHoi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DeThi_CauHois");

            entity.ToTable("tbDeThi_CauHoi", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.HasOne(d => d.MaCauHoiNavigation).WithMany(p => p.TbDeThiCauHois)
                .HasForeignKey(d => d.MaCauHoi)
                .HasConstraintName("FK_DeThi_CauHois_CauHois");

            entity.HasOne(d => d.MaDeThiNavigation).WithMany(p => p.TbDeThiCauHois)
                .HasForeignKey(d => d.MaDeThi)
                .HasConstraintName("FK_DeThi_CauHois_DeThis");
        });

        modelBuilder.Entity<TbKetQua>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_KetQuas");

            entity.ToTable("tbKetQua", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DapAn)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MaSinhVien)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MaDeThiCauHoiNavigation).WithMany(p => p.TbKetQuas)
                .HasForeignKey(d => d.MaDeThiCauHoi)
                .HasConstraintName("FK_KetQuas_DeThi_CauHois");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.TbKetQuas)
                .HasForeignKey(d => d.MaSinhVien)
                .HasConstraintName("FK_KetQuas_ThanhViens");
        });

        modelBuilder.Entity<TbMonHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MonHocs");

            entity.ToTable("tbMonHoc", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TenMonHoc).HasMaxLength(70);
        });

        modelBuilder.Entity<TbMucDo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MucDos");

            entity.ToTable("tbMucDo", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TenMucDo)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<TbThanhVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ThanhViens");

            entity.ToTable("tbThanhVien", "dbo");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Lop)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgaySinh).HasColumnName("NgaySInh");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenSinhVien).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
