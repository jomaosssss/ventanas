using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nuevo.Models;

public partial class CfepruebadosContext : DbContext
{
    public CfepruebadosContext()
    {
    }

    public CfepruebadosContext(DbContextOptions<CfepruebadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=KALI_93\\MSSQLSERVER01; database=CFEPRUEBADOS; Trusted_Connection=SSPI; Encrypt=false; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ClaveAgencia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClaveDivision)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClaveTipoMtto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClaveZona)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
