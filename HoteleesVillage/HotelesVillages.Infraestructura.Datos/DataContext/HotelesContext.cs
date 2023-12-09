using System;
using System.Collections.Generic;
using HotelesVillage.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace HotelesVillages.Infraestructura.Datos.DataContext;

public partial class HotelesContext : DbContext
{
    public HotelesContext()
    {
    }

    public HotelesContext(DbContextOptions<HotelesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Habitacione> Habitaciones { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelXHabitacion> HotelXHabitacions { get; set; }

    public virtual DbSet<ReservaHabitacion> ReservaHabitacions { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoGenero> TipoGeneros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<ViewSearchHotelxHabitacion> ViewSearchHotelxHabitacion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CostoBase)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_BASE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Impuesto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IMPUESTO");
            entity.Property(e => e.TipoHabitacion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TIPO_HABITACION");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("UBICACION");
            entity.Property(e => e.CantidadPersonas).HasColumnName("CANTIDAD_PERSONAS");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.ToTable("Hotel");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("UBICACION");
        });

        modelBuilder.Entity<HotelXHabitacion>(entity =>
        {
            entity.ToTable("Hotel_x_Habitacion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdHabitaciones).HasColumnName("ID_HABITACIONES");
            entity.Property(e => e.IdHotel).HasColumnName("ID_HOTEL");

            entity.HasOne(d => d.oHabitaciones).WithMany(p => p.HotelXHabitacions)
                .HasForeignKey(d => d.IdHabitaciones)
                .HasConstraintName("FK_Hotel_x_Habitacion_Habitaciones");

            entity.HasOne(d => d.oHotel).WithMany(p => p.HotelXHabitacions)
                .HasForeignKey(d => d.IdHotel)
                .HasConstraintName("FK_Hotel_x_Habitacion_Hotel");
        });

        modelBuilder.Entity<ReservaHabitacion>(entity =>
        {
            entity.ToTable("RESERVA_HABITACION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaCheckin)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CHECKIN");
            entity.Property(e => e.FechaCheckout)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CHECKOUT");

            entity.Property(e => e.IdHabitacion).HasColumnName("ID_HABITACION");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.ObservacionCancelado)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("OBSERVACION_CANCELADO");
            entity.Property(e => e.ServicioCancelado).HasColumnName("SERVICIO_CANCELADO");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.ReservaHabitacions)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK_RESERVA_HABITACION_Habitaciones");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ReservaHabitacions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_RESERVA_HABITACION_USUARIO");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.ToTable("TIPO_DOCUMENTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
        });

        modelBuilder.Entity<TipoGenero>(entity =>
        {
            entity.ToTable("TIPO_GENERO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("USUARIO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.IdGenero).HasColumnName("ID_GENERO");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_TIPO_DOCUMENTO");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.PrimerApellidoEmergencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO_EMERGENCIA");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_NOMBRE");
            entity.Property(e => e.PrimerNombreEmergencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_NOMBRE_EMERGENCIA");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");
            entity.Property(e => e.SegundoApellidoEmergencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO_EMERGENCIA");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_NOMBRE");
            entity.Property(e => e.SegundoNombreEmergencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_NOMBRE_EMERGENCIA");
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_CONTACTO");
            entity.Property(e => e.TelefonoContactoEmergencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_CONTACTO_EMERGENCIA");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("FK_USUARIO_TIPO_GENERO");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("FK_USUARIO_TIPO_DOCUMENTO");
        });

        modelBuilder.Entity<ViewSearchHotelxHabitacion>(entity =>
        {
            entity.HasNoKey()
                .ToView("View_SearchHotelxHabitacion");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Nombre)
           .HasMaxLength(150)
           .IsUnicode(false)
           .HasColumnName("NOMBRE");

            entity.Property(e => e.UbicacionHotel)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("UBICACION_HOTEL");

            entity.Property(e => e.FechaCheckin)
               .HasColumnType("datetime")
               .HasColumnName("FECHA_CHECKIN");

            entity.Property(e => e.FechaCheckout)
               .HasColumnType("datetime")
               .HasColumnName("FECHA_CHECKOUT");


            entity.Property(e => e.UbicacionHabitacion)
              .HasMaxLength(500)
              .IsUnicode(false)
              .HasColumnName("UBICACION_HABITACION");

            entity.Property(e => e.CantidadPersonas).HasColumnName("CANTIDAD_PERSONAS");

        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
