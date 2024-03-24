using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace assignment.EF;

public partial class NgoContext : DbContext
{
    public NgoContext()
    {
    }

    public NgoContext(DbContextOptions<NgoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CollectionRequest> CollectionRequests { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=ngo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CollectionRequest>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PRIMARY");

            entity.ToTable("CollectionRequest");

            entity.HasIndex(e => e.Eid, "Eid");

            entity.HasIndex(e => e.Rid, "Rid");

            entity.Property(e => e.Cid).HasColumnType("int(50)");
            entity.Property(e => e.Eid).HasColumnType("int(100)");
            entity.Property(e => e.MaxPreservationTime).HasMaxLength(500);
            entity.Property(e => e.Rid).HasColumnType("int(100)");
            entity.Property(e => e.Status).HasMaxLength(60);

            entity.HasOne(d => d.EidNavigation).WithMany(p => p.CollectionRequests)
                .HasForeignKey(d => d.Eid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Eid");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PRIMARY");

            entity.ToTable("Employee");

            entity.Property(e => e.Eid).HasColumnType("int(200)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Number).HasColumnType("int(60)");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Fid).HasName("PRIMARY");

            entity.ToTable("Food");

            entity.HasIndex(e => e.Cid, "Cid");

            entity.Property(e => e.Fid).HasColumnType("int(50)");
            entity.Property(e => e.Cid).HasColumnType("int(100)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Quantity).HasColumnType("int(50)");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Foods)
                .HasForeignKey(d => d.Cid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cid");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("PRIMARY");

            entity.ToTable("Restaurant");

            entity.Property(e => e.Rid).HasColumnType("int(100)");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
