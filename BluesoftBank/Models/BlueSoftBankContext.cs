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

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<TipoCliente> TipoClientes { get; set; }

    public virtual DbSet<TipoCuenta> TipoCuentas { get; set; }

    public virtual DbSet<TipoTransaccione> TipoTransacciones { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-CGRJAKH;Initial Catalog= BlueSoftBank;Trusted_Connection=True; Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__677F38F5CA7D42EB");

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
                .HasConstraintName("FK__Clientes__id_tip__75A278F5");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__Cuentas__C7E28685EB127C5A");

            entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");
            entity.Property(e => e.CiudadOrigen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciudad_origen");
            entity.Property(e => e.FechaApertura).HasColumnName("fecha_apertura");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdTipoCuenta).HasColumnName("id_tipo_cuenta");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("saldo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Cuentas__id_clie__7B5B524B");

            entity.HasOne(d => d.IdTipoCuentaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdTipoCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cuentas__id_tipo__7C4F7684");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.IdTipoCliente).HasName("PK__TipoClie__69D671C5B3FABF4D");

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
            entity.HasKey(e => e.IdTipoCuenta).HasName("PK__TipoCuen__2DF7D2A577D9BCB7");

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
            entity.HasKey(e => e.IdTipoTransaccion).HasName("PK__TipoTran__87B1206489E8E338");

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
            entity.HasKey(e => e.Id).HasName("PK__Transacc__3213E83F7BB7E515");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CiudadTransaccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciudad_transaccion");
            entity.Property(e => e.FechaTransaccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_transaccion");
            entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");
            entity.Property(e => e.IdTipoTransaccion).HasColumnName("id_tipo_transaccion");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("monto");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__id_cu__02084FDA");

            entity.HasOne(d => d.IdTipoTransaccionNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdTipoTransaccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__id_ti__02FC7413");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
