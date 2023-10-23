using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class RgeronimoExamenNdsContext : DbContext
{
    public RgeronimoExamenNdsContext()
    {
    }

    public RgeronimoExamenNdsContext(DbContextOptions<RgeronimoExamenNdsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cajero> Cajeros { get; set; }

    public virtual DbSet<Denominacione> Denominaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioCajero> UsuarioCajeros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3MSIM1L\\SQLEXPRESS; Database=RGeronimoExamenNDS; TrustServerCertificate=True; Trusted_Connection=True; User ID=sa; Password=1829301;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cajero>(entity =>
        {
            entity.HasKey(e => e.IdCajero).HasName("PK__Cajero__4B5E73C7C50E788C");

            entity.ToTable("Cajero");
        });

        modelBuilder.Entity<Denominacione>(entity =>
        {
            entity.HasKey(e => e.IdBillete).HasName("PK__Denomina__2B22175624983A83");

            entity.HasOne(d => d.IdCajeroNavigation).WithMany(p => p.Denominaciones)
                .HasForeignKey(d => d.IdCajero)
                .HasConstraintName("FK__Denominac__IdCaj__182C9B23");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.NoCuenta).HasName("PK__Usuario__66532A78A1B73893");

            entity.ToTable("Usuario");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nip).HasColumnName("NIP");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuarioCajero>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioCajero).HasName("PK__UsuarioC__6FC6B13547431580");

            entity.ToTable("UsuarioCajero");

            entity.HasOne(d => d.IdCajeroNavigation).WithMany(p => p.UsuarioCajeros)
                .HasForeignKey(d => d.IdCajero)
                .HasConstraintName("FK__UsuarioCa__IdCaj__15502E78");

            entity.HasOne(d => d.NoCuentaNavigation).WithMany(p => p.UsuarioCajeros)
                .HasForeignKey(d => d.NoCuenta)
                .HasConstraintName("FK__UsuarioCa__NoCue__145C0A3F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
