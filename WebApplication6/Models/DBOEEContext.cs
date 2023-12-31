﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication6.ViewModels;

namespace WebApplication6.Models;

public partial class DBOEEContext : DbContext
{
    public DBOEEContext(DbContextOptions<DBOEEContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<Dcode> Dcode { get; set; }

    public virtual DbSet<Defects> Defects { get; set; }

    public virtual DbSet<Downtimes> Downtimes { get; set; }

    public virtual DbSet<Machines> Machines { get; set; }

    public virtual DbSet<Outputs> Outputs { get; set; }

    public virtual DbSet<Shifts> Shifts { get; set; }

    public virtual DbSet<Times> Times { get; set; }

    public virtual DbSet<Toys> Toys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Dcode>(entity =>
        {
            entity.ToTable("DCode");

            entity.Property(e => e.DcodeId)
                .HasMaxLength(50)
                .HasColumnName("DCodeId");
            entity.Property(e => e.DcodeName)
                .HasMaxLength(50)
                .HasColumnName("DCodeName");
        });

        modelBuilder.Entity<Defects>(entity =>
        {
            entity.HasKey(e => e.DefectId).HasName("PK_Defect");

            entity.Property(e => e.DefectId).ValueGeneratedNever();
            entity.Property(e => e.DefectName).HasMaxLength(50);
        });

        modelBuilder.Entity<Downtimes>(entity =>
        {
            entity.HasKey(e => e.DowntimeId);

            entity.Property(e => e.DcodeId)
                .HasMaxLength(50)
                .HasColumnName("DCodeId");

            entity.HasOne(d => d.Dcode).WithMany(p => p.Downtimes)
                .HasForeignKey(d => d.DcodeId)
                .HasConstraintName("FK_Downtimes_DCode");

            entity.HasOne(d => d.Output).WithMany(p => p.Downtimes)
                .HasForeignKey(d => d.OutputId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Downtimes_Outputs");
        });

        modelBuilder.Entity<Machines>(entity =>
        {
            entity.HasKey(e => e.MachineId).HasName("PK_Machine");

            entity.Property(e => e.MachineNo)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Outputs>(entity =>
        {
            entity.HasKey(e => e.OutputId);

            entity.Property(e => e.DefectQty).HasColumnName("DefectQTY");
            entity.Property(e => e.OutputDate).HasMaxLength(50);
            entity.Property(e => e.OutputQTY).HasColumnName("OutputQTY");

            entity.HasOne(d => d.Defect).WithMany(p => p.Outputs)
                .HasForeignKey(d => d.DefectId)
                .HasConstraintName("FK_Outputs_Defects");

            entity.HasOne(d => d.Machine).WithMany(p => p.Outputs)
                .HasForeignKey(d => d.MachineId)
                .HasConstraintName("FK_Outputs_Machines");

            entity.HasOne(d => d.Time).WithMany(p => p.Outputs)
                .HasForeignKey(d => d.TimeId)
                .HasConstraintName("FK_Outputs_Times");

            entity.HasOne(d => d.Toy).WithMany(p => p.Outputs)
                .HasForeignKey(d => d.ToyId)
                .HasConstraintName("FK_Outputs_Toys");
        });

        modelBuilder.Entity<Shifts>(entity =>
        {
            entity.HasKey(e => e.ShiftId);

            entity.Property(e => e.ShiftId).ValueGeneratedNever();
            entity.Property(e => e.ShiftName).HasMaxLength(50);
        });

        modelBuilder.Entity<Times>(entity =>
        {
            entity.HasKey(e => e.TimeId).HasName("PK_Time");

            entity.Property(e => e.Shift).HasMaxLength(50);
            entity.Property(e => e.Tend)
                .HasMaxLength(50)
                .HasColumnName("TEnd");
            entity.Property(e => e.Tstart)
                .HasMaxLength(50)
                .HasColumnName("TStart");
        });

        modelBuilder.Entity<Toys>(entity =>
        {
            entity.HasKey(e => e.ToyId);

            entity.Property(e => e.ToyName).HasMaxLength(100);
            entity.Property(e => e.ToyPlan).HasColumnType("decimal(18, 1)");

            entity.HasOne(d => d.Category).WithMany(p => p.Toys)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Toys_Category");
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<WebApplication6.ViewModels.OutputViewModel> OutputViewModel { get; set; } = default!;
}