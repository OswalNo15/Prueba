using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PruebaInfodesingBackend.Models.Data;

namespace PruebaInfodesingBackend.DAL.Context;

public partial class PruebaInfoDesignContext : DbContext
{
    public PruebaInfoDesignContext()
    {
    }

    public PruebaInfoDesignContext(DbContextOptions<PruebaInfoDesignContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ConsumoPorTramo> ConsumoPorTramos { get; set; }

    public virtual DbSet<CostoPorTramo> CostoPorTramos { get; set; }


    public virtual DbSet<Linea> Lineas { get; set; }

    public virtual DbSet<PerdidasPorTramo> PerdidasPorTramos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConsumoPorTramo>(entity =>
        {
            entity.HasKey(e => e.IdConsumoxTramo);

            entity.ToTable("CONSUMO_POR_TRAMO");

            entity.Property(e => e.IdConsumoxTramo).HasColumnName("ID_CONSUMOX_TRAMO");
            entity.Property(e => e.CodLinea).HasColumnName("COD_LINEA");
            entity.Property(e => e.ConsumoComercialWh).HasColumnName("CONSUMO_COMERCIAL_WH");
            entity.Property(e => e.ConsumoIndustrialWh).HasColumnName("CONSUMO_INDUSTRIAL_WH");
            entity.Property(e => e.ConsumoResidencialWh).HasColumnName("CONSUMO_RESIDENCIAL_WH");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");

            entity.HasOne(d => d.oLinea).WithMany(p => p.ConsumoPorTramos)
                .HasForeignKey(d => d.CodLinea)
                .HasConstraintName("FK_CONSUMO_POR_TRAMO_LINEA");
        });

        modelBuilder.Entity<CostoPorTramo>(entity =>
        {
            entity.HasKey(e => e.IdCostoxTramo);

            entity.ToTable("COSTO_POR_TRAMO");

            entity.Property(e => e.IdCostoxTramo).HasColumnName("ID_COSTOX_TRAMO");
            entity.Property(e => e.CodLinea).HasColumnName("COD_LINEA");
            entity.Property(e => e.CostoComercialWh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COSTO_COMERCIAL_WH");
            entity.Property(e => e.CostoIndustrialWh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COSTO_INDUSTRIAL_WH");
            entity.Property(e => e.CostoResidencialWh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COSTO_RESIDENCIAL_WH");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");

            entity.HasOne(d => d.oLinea).WithMany(p => p.CostoPorTramos)
                .HasForeignKey(d => d.CodLinea)
                .HasConstraintName("FK_COSTO_POR_TRAMO_LINEA");
        });

        

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.CodLinea);

            entity.ToTable("LINEA");

            entity.Property(e => e.CodLinea).HasColumnName("COD_LINEA");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<PerdidasPorTramo>(entity =>
        {
            entity.HasKey(e => e.IdPerdidaxTramo);

            entity.ToTable("PERDIDAS_POR_TRAMO");

            entity.Property(e => e.IdPerdidaxTramo).HasColumnName("ID_PERDIDAX_TRAMO");
            entity.Property(e => e.CodLinea).HasColumnName("COD_LINEA");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.PerdidaComercialPorcentaje)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PERDIDA_COMERCIAL_PORCENTAJE");
            entity.Property(e => e.PerdidaIndustrialPorcentaje)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PERDIDA_INDUSTRIAL_PORCENTAJE");
            entity.Property(e => e.PerdidaResidencialPorcentaje)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PERDIDA_RESIDENCIAL_PORCENTAJE");

            entity.HasOne(d => d.oLinea).WithMany(p => p.PerdidasPorTramos)
                .HasForeignKey(d => d.CodLinea)
                .HasConstraintName("FK_PERDIDAS_POR_TRAMO_LINEA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
