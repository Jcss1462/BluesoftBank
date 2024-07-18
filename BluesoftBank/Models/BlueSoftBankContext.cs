using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BluesoftBank.Models;

public partial class BlueSoftBankContext : DbContext
{
    public BlueSoftBankContext()
    {
    }

    public BlueSoftBankContext(DbContextOptions<BlueSoftBankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<TipoCliente> TipoClientes { get; set; }

    public virtual DbSet<TipoCuenta> TipoCuentas { get; set; }

    public virtual DbSet<TipoTransaccione> TipoTransacciones { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("PK__Ciudades__AEA2A71BB1BD9BB7");

            entity.Property(e => e.IdCiudad)
                .ValueGeneratedNever()
                .HasColumnName("idCiudad");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ciudad");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__677F38F56490D8D5");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.ContactoPrincipal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contacto_principal");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.IdTipoCliente).HasColumnName("id_tipo_cliente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_comercial");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_documento");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("razon_social");
            entity.Property(e => e.Ruc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono_contacto");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_documento");

            entity.HasOne(d => d.IdTipoClienteNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clientes__id_tip__6DCC4D03");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__Cuentas__C7E28685F3B58EE1");

            entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");
            entity.Property(e => e.FechaApertura).HasColumnName("fecha_apertura");
            entity.Property(e => e.IdCiudadOrigen).HasColumnName("id_ciudad_origen");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdTipoCuenta).HasColumnName("id_tipo_cuenta");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("saldo");

            entity.HasOne(d => d.IdCiudadOrigenNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdCiudadOrigen)
                .HasConstraintName("FK__Cuentas__id_ciud__756D6ECB");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Cuentas__id_clie__73852659");

            entity.HasOne(d => d.IdTipoCuentaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdTipoCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cuentas__id_tipo__74794A92");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.IdTipoCliente).HasName("PK__TipoClie__69D671C51B94C03B");

            entity.Property(e => e.IdTipoCliente)
                .ValueGeneratedNever()
                .HasColumnName("id_tipo_cliente");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TipoCuenta>(entity =>
        {
            entity.HasKey(e => e.IdTipoCuenta).HasName("PK__TipoCuen__2DF7D2A54488ACD4");

            entity.Property(e => e.IdTipoCuenta)
                .ValueGeneratedNever()
                .HasColumnName("id_tipo_cuenta");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TipoTransaccione>(entity =>
        {
            entity.HasKey(e => e.IdTipoTransaccion).HasName("PK__TipoTran__87B120649974C478");

            entity.Property(e => e.IdTipoTransaccion)
                .ValueGeneratedNever()
                .HasColumnName("id_tipo_transaccion");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transacc__3213E83FC865DC22");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("after_insert_transaccion");
                    tb.HasTrigger("before_insert_transaccion");
                });

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaTransaccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_transaccion");
            entity.Property(e => e.IdCiudadTransaccion).HasColumnName("id_ciudad_transaccion");
            entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");
            entity.Property(e => e.IdTipoTransaccion).HasColumnName("id_tipo_transaccion");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("monto");

            entity.HasOne(d => d.IdCiudadTransaccionNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdCiudadTransaccion)
                .HasConstraintName("FK__Transacci__id_ci__7D0E9093");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__id_cu__7B264821");

            entity.HasOne(d => d.IdTipoTransaccionNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdTipoTransaccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__id_ti__7C1A6C5A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
