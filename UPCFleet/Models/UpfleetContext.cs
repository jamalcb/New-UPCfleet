using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UPCFleet.Models;

public partial class UpfleetContext : DbContext
{
    public UpfleetContext()
    {
    }

    public UpfleetContext(DbContextOptions<UpfleetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barge> Barges { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<PeachtreeExportedArchive> PeachtreeExportedArchives { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Transfer> Transfers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5N8J203;Initial Catalog=UPFleet;Integrated Security=True; Trust server certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Barge__3214EC27A5EC3C02");

            entity.ToTable("Barge");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Barge1)
                .HasMaxLength(255)
                .HasColumnName("Barge");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Owner).HasMaxLength(255);
            entity.Property(e => e.Size).HasMaxLength(255);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Owner__3214EC279E6D0CFA");

            entity.ToTable("Owner");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Account).HasMaxLength(255);
            entity.Property(e => e.Address1).HasMaxLength(255);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Company).HasMaxLength(255);
            entity.Property(e => e.Owner1)
                .HasMaxLength(255)
                .HasColumnName("Owner");
            entity.Property(e => e.State).HasMaxLength(255);
            entity.Property(e => e.Zip).HasMaxLength(255);
        });

        modelBuilder.Entity<PeachtreeExportedArchive>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Peachtre__3214EC27067633C8");

            entity.ToTable("PeachtreeExportedArchive");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Account).HasMaxLength(255);
            entity.Property(e => e.Closed).HasMaxLength(255);
            entity.Property(e => e.CustomerPo)
                .HasMaxLength(255)
                .HasColumnName("\"Customer PO\"");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Glaccount)
                .HasMaxLength(255)
                .HasColumnName("GLaccount");
            entity.Property(e => e.Invitem).HasMaxLength(255);
            entity.Property(e => e.Owner).HasMaxLength(255);
            entity.Property(e => e.Qnty).HasMaxLength(255);
            entity.Property(e => e.SalesOrder).HasMaxLength(255);
            entity.Property(e => e.SalesRepresentativeId)
                .HasMaxLength(255)
                .HasColumnName("\"Sales Representative ID\"");
            entity.Property(e => e.SalesTaxAuth).HasMaxLength(255);
            entity.Property(e => e.SalesTaxId)
                .HasMaxLength(255)
                .HasColumnName("\"Sales Tax ID\"");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC276A7DBF46");

            entity.ToTable("Transaction");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Barge).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.Transaction1).HasColumnName("Transaction");
        });

        modelBuilder.Entity<Transfer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transfer__3214EC272F896376");

            entity.ToTable("Transfer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.From).HasColumnType("datetime");
            entity.Property(e => e.FromIns).HasMaxLength(255);
            entity.Property(e => e.InsuranceDays).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.To).HasColumnType("datetime");
            entity.Property(e => e.Transfer1).HasColumnName("Transfer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
