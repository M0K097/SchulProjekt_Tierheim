using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework.DbModels;

public partial class TierheimContext : DbContext
{
    public TierheimContext()
    {
    }

    public TierheimContext(DbContextOptions<TierheimContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Account { get; set; }

    public virtual DbSet<Anfragen> Anfragen { get; set; }

    public virtual DbSet<Tiere> Tiere { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-59MTDK9R;Initial Catalog=Tierheim; Integrated Security=SSPI; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.NutzerId).HasName("PK__Account__34A15DAD78B473E6");

            entity.Property(e => e.NutzerId).HasColumnName("Nutzer_ID");
            entity.Property(e => e.Benutzername)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasColumnName("is_ADMIN");
            entity.Property(e => e.Passwort)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Anfragen>(entity =>
        {
            entity.HasKey(e => e.AnfrageId).HasName("PK__Anfragen__CB00C311EB80294A");

            entity.Property(e => e.AnfrageId).HasColumnName("Anfrage_ID");
            entity.Property(e => e.NutzerId).HasColumnName("Nutzer_ID");
            entity.Property(e => e.TierId).HasColumnName("Tier_ID");

            entity.HasOne(d => d.Nutzer).WithMany(p => p.Anfragen)
                .HasForeignKey(d => d.NutzerId)
                .HasConstraintName("FK__Anfragen__Nutzer__3B75D760");

            entity.HasOne(d => d.Tier).WithMany(p => p.Anfragen)
                .HasForeignKey(d => d.TierId)
                .HasConstraintName("FK__Anfragen__Tier_I__3C69FB99");
        });

        modelBuilder.Entity<Tiere>(entity =>
        {
            entity.HasKey(e => e.TierId).HasName("PK__Tiere__754A1AE3A57B0B9A");

            entity.Property(e => e.TierId).HasColumnName("Tier_ID");
            entity.Property(e => e.Beschreibung)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");
            entity.Property(e => e.Tierart)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Tiername)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
